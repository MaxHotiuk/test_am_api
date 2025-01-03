using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;
using SimpleAPI.Helpers;

namespace SimpleAPI.Data;

public class IncidentDbContext(DbContextOptions<IncidentDbContext> options) : DbContext(options)
{
    public required DbSet<Account> Accounts { get; set; }
    public required DbSet<Contact> Contacts { get; set; }
    public required DbSet<Incident> Incidents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired();

            entity.HasOne(d => d.Incident)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IncidentName)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.Property(e => e.IncidentName)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<SequentialStringValueGenerator>();
        });
    }
}