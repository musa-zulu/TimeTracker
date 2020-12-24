using System.Threading.Tasks;

namespace TimeTracker.Persistence
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync();
    }
}
