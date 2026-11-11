using Company.DTOs.Department;

namespace Company.Services;

public interface IDepartmentService
{
    Task<List<DepartmentDto>> GetDepartment();

    Task<DepartmentDto?> GetDepartment(int id);

    Task<DepartmentDto> CreateDepartment(CreateDepartmentDto dto);

    Task<DepartmentDto?> UpdateDepartment(
        int id,
        UpdateDepartmentDto dto);

    Task<bool> DeleteDepartment(int id);
}

