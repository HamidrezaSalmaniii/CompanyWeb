namespace Company.DTOs.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
