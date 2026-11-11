using Company.DTOs.Employee;

namespace Company.Services;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetEmployee();

    Task<EmployeeDto?> GetEmployee(int id);
    Task<int> TestAny();

    Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto);

    Task<EmployeeDto?> UpdateEmployee(
        int id,
        UpdateEmployeeDto dto);

    Task<bool> DeleteEmployee(int id);
}