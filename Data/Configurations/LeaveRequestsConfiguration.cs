using Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LeaveRequestsConfiguration : IEntityTypeConfiguration<LeaveRequests>
{
    public void Configure(EntityTypeBuilder<LeaveRequests> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EmployeeId)
            .IsRequired();

        builder.Property(e => e.LeaveType)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired();

        builder.Property(e => e.Reason)
            .IsRequired();

        builder.Property(e => e.Status)
            .IsRequired();

        builder.Property(e => e.ApprovedBy)
            .IsRequired(false);

        builder.Property(e => e.ApprovedAt)
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .IsRequired();
    }
}