namespace Company.DTOs.LeaveRequest
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }

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
