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
    public class TimeSlotsService : ITimeSlotsService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public TimeSlotsService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Response<List<TimeSlot>>> GetTimeSlotsAsync()
        {
            try
            {
                var timeSlots = await _applicationDbContext
                    .TimeSlots
                    .ToListAsync();

                return new Response<List<TimeSlot>>
                {
                    Succeeded = true,
                    Data = timeSlots,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<List<TimeSlot>>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> AddTimeSlotAsync(TimeSlot newTimeSlot)
        {
            try
            {
                await _applicationDbContext.TimeSlots.AddAsync(newTimeSlot);
                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Timeslot has been successfully added."
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

        public async Task<Response<bool>> DeleteTimeSlotById(Guid timeSlotId)
        {
            try
            {
                var timeSlot = await GetTimeSlotById(timeSlotId);
                if (timeSlot == null) throw new ArgumentNullException(nameof(timeSlot));

                _applicationDbContext.TimeSlots.Remove(timeSlot.Data);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Timeslot deleted successfully!!!"
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

        public async Task<Response<TimeSlot>> GetTimeSlotById(Guid timeSlotId)
        {
            try
            {
                var timeSlot = await _applicationDbContext
                                      .TimeSlots
                                      .FirstOrDefaultAsync(x => x.TimeSlotId == timeSlotId);

                return new Response<TimeSlot>
                {
                    Succeeded = true,
                    Data = timeSlot,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<TimeSlot>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> UpdateTimeSlotAsync(TimeSlot timeSlotToUpdate)
        {
            try
            {
                _applicationDbContext.TimeSlots.Update(timeSlotToUpdate);

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
