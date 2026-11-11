using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentsConfiguration
    : IEntityTypeConfiguration<Departments>
{
    public void Configure(EntityTypeBuilder<Departments> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.Code)
            .IsRequired();

        builder.Property(d => d.Desciption);

        builder.Property(d => d.ManagerId)
            .IsRequired(false);

        builder.Property(d => d.ParentDepartmentId)
            .IsRequired(false);

        builder.Property(d => d.CompanyId)
            .IsRequired();

        builder.Property(d => d.IsActive)
            .IsRequired();
    }
}
