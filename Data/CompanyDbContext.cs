using Company.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Data;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }


    public DbSet<Employees> Employees => Set<Employees>();
    public DbSet<Companies> Companies => Set<Companies>();
    public DbSet<Departments> Departments => Set<Departments>();
    public DbSet<LeaveRequests> LeaveRequests => Set<LeaveRequests>();
    public DbSet<Positions> Positions => Set<Positions>();
    public DbSet<Roles> Roles => Set<Roles>();
    public DbSet<Users> Users => Set<Users>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Company → Departments
        modelBuilder.Entity<Departments>()
            .HasOne(d => d.Company)
            .WithMany(c => c.Departments)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        // Department → Employees
        modelBuilder.Entity<Employees>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Department → Positions
        modelBuilder.Entity<Positions>()
            .HasOne(p => p.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Department → Parent Department
        modelBuilder.Entity<Departments>()
            .HasOne(d => d.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(d => d.ParentDepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee → Position
        modelBuilder.Entity<Employees>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee → Manager (Self Relationship)
        modelBuilder.Entity<Employees>()
            .HasOne(e => e.Manager)
            .WithMany(e => e.Subordinates)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee → LeaveRequests
        modelBuilder.Entity<LeaveRequests>()
            .HasOne(l => l.Employee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(l => l.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee → Approved LeaveRequests
        modelBuilder.Entity<LeaveRequests>()
            .HasOne(l => l.Approver)
            .WithMany(e => e.ApprovedLeaveRequests)
            .HasForeignKey(l => l.ApprovedBy)
            .OnDelete(DeleteBehavior.NoAction);

        // Employee → User
        modelBuilder.Entity<Users>()
            .HasOne(u => u.Employee)
            .WithMany(e => e.Users)
            .HasForeignKey(u => u.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        // User → Role
        modelBuilder.Entity<Users>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}