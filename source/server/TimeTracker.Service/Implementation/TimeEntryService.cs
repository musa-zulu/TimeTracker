using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Persistence;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Implementation
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public TimeEntryService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Response<List<TimeEntry>>> GetTimeEntriesAsync()
        {
            try
            {
                var timeEntries = await _applicationDbContext
                    .TimeEntries
                    .ToListAsync();

                return new Response<List<TimeEntry>>
                {
                    Succeeded = true,
                    Data = timeEntries,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<List<TimeEntry>>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> AddTimeEntryAsync(TimeEntry newTimeEntry)
        {
            try
            {
                await _applicationDbContext.TimeEntries.AddAsync(newTimeEntry);
                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "timeEntry has been successfully added."
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> DeleteTimeEntryById(Guid timeEntryId)
        {
            try
            {
                var timeEntry = await GetTimeEntryById(timeEntryId);
                if (timeEntry is null) throw new ArgumentNullException(nameof(timeEntry));

                _applicationDbContext.TimeEntries.Remove(timeEntry.Data);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "timeEntry deleted successfully!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<TimeEntry>> GetTimeEntryById(Guid timeEntryId)
        {
            try
            {
                var timeEntry = await _applicationDbContext
                                      .TimeEntries
                                      .FirstOrDefaultAsync(x => x.TimeEntryId == timeEntryId);

                return new Response<TimeEntry>
                {
                    Succeeded = true,
                    Data = timeEntry,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<TimeEntry>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> UpdateTimeEntryAsync(TimeEntry timeEntryToUpdate)
        {
            try
            {
                _applicationDbContext.TimeEntries.Update(timeEntryToUpdate);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Data has been updated successfully!!"
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }
    }
}
