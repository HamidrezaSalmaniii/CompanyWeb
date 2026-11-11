using AutoMapper;
using Company.Data;
using Company.DTOs.Department;
using Company.Entities;
using Company.Services;
using CompanyWebApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetDepartment()
        {
            var departments = await _context.Departments
                .Include(d => d.Company)
                .Include(d => d.Manager)
                .Include(d => d.ParentDepartment)
                .Include(d => d.SubDepartments)
                .Include(d => d.Employees)
                .Include(d => d.Positions)
                .ToListAsync();

            return _mapper.Map<List<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto?> GetDepartment(int id)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                return null;

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> CreateDepartment(CreateDepartmentDto dto)
        {
            // Business Validation

            var departmentExists = await _context.Departments
                .AnyAsync(d => d.Id == dto.ParentDepartmentId);

            if (!departmentExists)
                throw new NotFoundException("Department not found.");

            var companyExists = await _context.Companies
            .AnyAsync(p => p.Id == dto.CompanyId);

            if (!companyExists)
                throw new NotFoundException("Company not found.");

            if (dto.ManagerId.HasValue)
            {
                var managerExists = await _context.Employees
                    .AnyAsync(e => e.Id == dto.ManagerId.Value);

                if (!managerExists)
                    throw new NotFoundException("Manager not found.");
            }
            // Create Department

            var department = _mapper.Map<Departments>(dto);

            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return _mapper.Map<DepartmentDto>(department);
        }
        public async Task<DepartmentDto?> UpdateDepartment(
            int id,
            UpdateDepartmentDto dto)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return null;

            _mapper.Map(dto, department);

            await _context.SaveChangesAsync();

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return false;

            var hasEmployees = await _context.Employees.AnyAsync(e => e.DepartmentId == id);
            if (hasEmployees)
                throw new Exception("Department has employees.");

            var hasPositions = await _context.Positions.AnyAsync(p => p.DepartmentId == id);
            if (hasPositions)
                throw new Exception("Department has positions.");

            var hasSubDepartments = await _context.Departments.AnyAsync(d => d.ParentDepartmentId == id);
            if (hasSubDepartments)
                throw new Exception("Department has sub-departments.");

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
