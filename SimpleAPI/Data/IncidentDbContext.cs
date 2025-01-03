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
        modelBuilder.Entity<Contact>()
            .HasOne(c => c.Account)
            .WithMany(a => a.Contacts)
            .HasForeignKey(c => c.AccountName);

        modelBuilder.Entity<Incident>()
            .HasOne(i => i.Account)
            .WithMany(a => a.Incidents)
            .HasForeignKey(i => i.AccountName)
            .IsRequired(false); 

        modelBuilder.Entity<Account>()
            .HasIndex(a => a.Name)
            .IsUnique();

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.Property(e => e.IncidentName)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<SequentialStringValueGenerator>();
        });
    }
}