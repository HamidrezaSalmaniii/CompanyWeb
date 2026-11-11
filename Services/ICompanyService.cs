using Company.DTOs.Company;

namespace Company.Services;

public interface ICompanyService
{
    Task<List<CompanyDto>> GetCompany();

    Task<CompanyDto?> GetCompany(int id);

    Task<CompanyDto> CreateCompany(CreateCompanyDto dto);

    Task<CompanyDto?> UpdateCompany(
        int id,
        UpdateCompanyDto dto);

    Task<bool> DeleteCompany(int id);
}