namespace Company.DTOs.Roles
{
    public class CreateRoleDto
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
