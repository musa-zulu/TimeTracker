using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Persistence;

public interface IApplicationDbContext
{
    DbSet<Task> Tasks { get; set; }

    DbSet<TimeEntry> TimeEntries { get; set; }

    Task<int> SaveChangesAsync(string userName = null);
}
