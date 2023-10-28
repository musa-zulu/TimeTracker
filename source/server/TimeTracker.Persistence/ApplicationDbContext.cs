using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain;
using TimeTracker.Domain.Entities;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    // This constructor is used of runit testing
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("DataSource=app.db");
        }
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }

    public async Task<int> SaveChangesAsync(string userName = null)
    {
        userName ??= "SYS";
        var addedAuditedEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(p => p.State == EntityState.Added)
            .Select(p => p.Entity);
        var modifiedAuditedEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(p => p.State == EntityState.Modified)
            .Select(p => p.Entity);
        var now = DateTime.UtcNow;
        foreach (var added in addedAuditedEntities)
        {
            added.DateCreated = now;
            added.AddedBy = userName;
            added.DateUpdated = now;
            added.UpdatedBy = userName;
        }

        foreach (var modified in modifiedAuditedEntities)
        {
            if (modified.DateCreated == DateTime.MinValue)
                modified.DateCreated = now;
            if (string.IsNullOrEmpty(modified.AddedBy))
                modified.AddedBy = userName;
            modified.DateUpdated = now;
            modified.UpdatedBy = userName;
        }
        return await base.SaveChangesAsync();
    }
}
