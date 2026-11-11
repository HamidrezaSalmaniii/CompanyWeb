using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EmployeeCode)
            .IsRequired();

        builder.Property(e => e.NationalId)
            .IsRequired();

        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength (50)
            .IsRequired();

        builder.Property(e => e.BirthDate)
            .IsRequired();

        builder.Property(e => e.Gender)
            .IsRequired();

        builder.Property(e => e.PhoneNumber)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired();

        builder.Property(e => e.Address)
            .IsRequired();

        builder.Property(e => e.DepartmentId)
            .IsRequired();

        builder.Property(e => e.PositionId)
            .IsRequired();

        builder.Property(e => e.ManagerId)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired();

    }
}