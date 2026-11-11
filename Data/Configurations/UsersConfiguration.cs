using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EmployeeId)
            .IsRequired();

        builder.Property(e => e.UserName)
            .IsRequired();

        builder.Property(e => e.PasswordHash)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.LastLoginAt)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired();

    }
}