using AutoMapper;
using Company.Data;
using Company.DTOs.Company;
using Company.Entities;
using Company.Services;
using CompanyWebApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Services.Company

{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> GetCompany()
        { 
            var companies = await _context.Companies
                .Include(c => c.Departments)
                .ToListAsync();

            return _mapper.Map<List<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetCompany(int id)
        {
            var companies = await _context.Companies
                .Include(c => c.Departments)
                .FirstOrDefaultAsync(e =>e.Id == id);

            if (companies == null)
                return null;

            return _mapper.Map<CompanyDto>(companies);
        }

        public async Task<CompanyDto> CreateCompany(CreateCompanyDto dto)
        {
            var company = _mapper.Map<Companies>(dto);

            company.CreatedAt = DateTime.Now;
            company.UpdatedAt = DateTime.Now;

            _context.Companies.Add(company);

            await _context.SaveChangesAsync();

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto?> UpdateCompany(int id,
            UpdateCompanyDto dto)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null) 
                return null;

            _mapper.Map(dto, company);

            company.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
                return false;

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
