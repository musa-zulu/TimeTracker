using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Service.Contract
{
    public interface ITimeEntryService
    {
        Task<Response<bool>> AddTimeEntryAsync(TimeEntry newTimeEntry);
        Task<Response<bool>> UpdateTimeEntryAsync(TimeEntry timeEntryToUpdate);
        Task<Response<List<TimeEntry>>> GetTimeEntriesAsync();
        Task<Response<TimeEntry>> GetTimeEntryById(Guid timeEntryId);
        Task<Response<bool>> DeleteTimeEntryById(Guid timeEntryId);
    }
}
