using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<TimeSlot> TimeSlots { get; set; }

        Task<int> SaveChangesAsync();
    }
}
