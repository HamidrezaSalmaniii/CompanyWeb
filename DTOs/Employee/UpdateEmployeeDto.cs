namespace Company.DTOs.Employee;

public class UpdateEmployeeDto
{
    public int EmployeeCode { get; set; }
    public string NationalId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public byte Gender { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public int DepartmentId { get; set; }
    public int PositionId { get; set; }
    public int? ManagerId { get; set; }

    public bool IsActive { get; set; }
    public int Salary { get; set; }
}