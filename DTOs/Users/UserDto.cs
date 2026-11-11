namespace Company.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
