using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using TestTask.Models.Dbo;

namespace TestTask;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<ContainerDbo> Containers { get; set; }
    public DbSet<OperationDbo> Operations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ContainerDbo>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.DateReceived)
                .HasColumnType("timestamp with time zone");
        });

        modelBuilder.Entity<OperationDbo>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp with time zone");
            entity.HasOne(e => e.Container)
                .WithMany()
                .HasForeignKey(e => e.ContainerID);
        });
    }
}