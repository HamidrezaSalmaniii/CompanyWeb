using Company.Entities;

public class Users
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int RoleId { get; set; }

    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Employees? Employee { get; set; }
    public Roles? Role { get; set; }
}