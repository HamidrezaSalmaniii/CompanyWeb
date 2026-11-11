namespace CompanyWebApp.DTOs
{
    public class UpdateLeaveRequestDto
    {
        public byte LeaveType { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Reason { get; set; } = null!;

        public byte Status { get; set; }

    }
}
