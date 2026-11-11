namespace Company.DTOs
{
    public class CreateLeaveRequestDto
    {
        public int EmployeeId { get; set; }

        public byte LeaveType { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Reason { get; set; } = null!;

        public byte Status { get; set; }

        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
