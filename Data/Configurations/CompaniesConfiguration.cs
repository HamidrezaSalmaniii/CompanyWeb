using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompaniesConfiguration : IEntityTypeConfiguration<Companies>
{
    public void Configure(EntityTypeBuilder<Companies> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Code)
            .IsRequired();

        builder.Property(e => e.RegistrationNumber)
            .IsRequired();

        builder.Property(e => e.LegalIdentifier)
            .IsRequired();

        builder.Property(e => e.EconomicCode)
            .IsRequired();

        builder.Property(e => e.PhoneNumber)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired();

        builder.Property(e => e.Address)
            .IsRequired();

        builder.Property(e => e.WebSite)
            .IsRequired(false);

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}