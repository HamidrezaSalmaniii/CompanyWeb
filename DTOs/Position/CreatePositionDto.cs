namespace Company.DTOs.Position
{
    public class CreatePositionDto
    {
        public string Title { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Descriptions { get; set; } = null!;

        public int DepartmentId { get; set; }

        public byte Level { get; set; }

        public bool IsActive { get; set; }
    }
}
