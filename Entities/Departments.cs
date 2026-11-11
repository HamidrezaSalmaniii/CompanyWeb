namespace Company.Entities;

public class Departments
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Desciption { get; set; } = null!;

    public int? ManagerId { get; set; }

    public int? ParentDepartmentId { get; set; }

    public bool IsActive { get; set; }

    public int CompanyId { get; set; }

    public Employees? Manager { get; set; }

    public Companies? Company { get; set; }

    public Departments? ParentDepartment { get; set; }

    public ICollection<Departments> SubDepartments { get; set; } = new List<Departments>();

    public ICollection<Employees> Employees { get; set; } = new List<Employees>();

    public ICollection<Positions> Positions { get; set; } = new List<Positions>();
}