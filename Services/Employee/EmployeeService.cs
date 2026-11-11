using AutoMapper;
using Company.Data;
using Company.DTOs.Employee;
using Company.Entities;
using Company.Services;
using CompanyWebApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly CompanyDbContext _context;
    private readonly IMapper _mapper;
    public EmployeeService(CompanyDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EmployeeDto>> GetEmployee()
    {
        var employees = await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .OrderBy(e => e.LastName)
            .ToListAsync();


        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public async Task<int> TestAny()
    {
        var exists = await _context.Employees
            .CountAsync(e => e.DepartmentId == 1);
        return exists;
    }

    public async Task<EmployeeDto?> GetEmployee(int id)
    {
        var employee = await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
            return null;

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto)
    {
            // Business Validation

    var departmentExists = await _context.Departments
        .AnyAsync(d => d.Id == dto.DepartmentId);

    if (!departmentExists)
            throw new NotFoundException("Department not found.");

        var positionExists = await _context.Positions
        .AnyAsync(p => p.Id == dto.PositionId);

    if (!positionExists)
        throw new NotFoundException("Position not found.");

    if (dto.ManagerId.HasValue)
    {
        var managerExists = await _context.Employees
            .AnyAsync(e => e.Id == dto.ManagerId.Value);

        if (!managerExists)
            throw new NotFoundException("Manager not found.");
    }

    // Create Employee

    var employee = _mapper.Map<Employees>(dto);

    employee.CreatedAt = DateTime.Now;
    employee.UpdatedAt = DateTime.Now;

    _context.Employees.Add(employee);

    await _context.SaveChangesAsync();

    return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto?> UpdateEmployee(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
            return null;

        _mapper.Map(dto, employee);

        employee.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
            return false;

        var isDepartmentManager = await _context.Departments.AnyAsync(d => d.ManagerId == id);

        if (isDepartmentManager)
            throw new Exception("Employee is a manager of a department.");
        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }

}