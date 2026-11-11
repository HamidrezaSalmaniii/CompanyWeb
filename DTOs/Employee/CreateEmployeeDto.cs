using System.ComponentModel.DataAnnotations;

public class CreateEmployeeDto
{
    public int EmployeeCode { get; set; }
    [Required]
    [StringLength(10,MinimumLength = 10)]
    public string NationalId { get; set; } = null!;
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    [Range(0,1)]
    public byte Gender { get; set; }
    [Required,Phone]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public int DepartmentId { get; set; }
    public int PositionId { get; set; }
    public int? ManagerId { get; set; }

    public bool IsActive { get; set; }
}