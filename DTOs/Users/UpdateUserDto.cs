namespace Company.DTOs.Users;

public class UpdateUserDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int EmployeeId { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }

    public string? Password { get; set; }
}