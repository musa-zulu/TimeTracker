using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TimeTracker.Domain;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence
{
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

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IBaseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Created").CurrentValue = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DateUpdated").CurrentValue = DateTime.Now;
                    }
                }
            }
            return await base.SaveChangesAsync();
        }


    }
}
