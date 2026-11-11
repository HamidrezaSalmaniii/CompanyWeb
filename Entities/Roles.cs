namespace Company.Entities;

public class Roles
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public ICollection<Users> Users { get; set; } = new List<Users>();
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}