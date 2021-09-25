using TimeTracker.Domain.Entities;
using TimeTracker.Persistence;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Implementation
{
    public class TimeSlotsService : GenericService<TimeSlot>, ITimeSlotsService
    {
        public TimeSlotsService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
