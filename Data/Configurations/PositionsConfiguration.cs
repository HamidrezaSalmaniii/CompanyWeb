using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PositionsConfiguration : IEntityTypeConfiguration<Positions>
{
    public void Configure(EntityTypeBuilder<Positions> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired();

        builder.Property(e => e.Code)
            .IsRequired();

        builder.Property(e => e.Descriptions)
            .IsRequired();

        builder.Property(e => e.DepartmentId)
            .IsRequired();

        builder.Property(e => e.Level)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired();

    }
}