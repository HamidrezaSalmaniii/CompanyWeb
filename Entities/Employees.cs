namespace Company.Entities;

public class Employees
{
    public int Id { get; set; }

    public int EmployeeCode { get; set; }

    public string NationalId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public byte Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int PositionId { get; set; }

    public int? ManagerId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }


    // Relations

    public Departments? Department { get; set; }

    public Positions? Position { get; set; }

    public Employees? Manager { get; set; }

    public ICollection<Employees> Subordinates { get; set; } = new List<Employees>();

    public ICollection<LeaveRequests> LeaveRequests { get; set; } = new List<LeaveRequests>();

    public ICollection<LeaveRequests> ApprovedLeaveRequests { get; set; } = new List<LeaveRequests>();

    public ICollection<Users> Users { get; set; } = new List<Users>();
}