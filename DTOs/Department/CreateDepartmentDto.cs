namespace Company.DTOs.Department
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Desciption { get; set; } = null!;

        public int? ManagerId { get; set; }

        public int? ParentDepartmentId { get; set; }

        public int CompanyId { get; set; }

        public bool IsActive { get; set; }
    }
}
