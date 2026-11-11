namespace Company.DTOs.Position
{
    public class PositionDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Descriptions { get; set; } = null!;

        public int DepartmentId { get; set; }

        public byte Level { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
