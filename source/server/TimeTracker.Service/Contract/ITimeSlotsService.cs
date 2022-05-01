using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Service.Contract
{
    public interface ITimeSlotsService
    {
        Task<Response<bool>> AddTimeSlotAsync(TimeSlot newTimeSlot);
        Task<Response<bool>> UpdateTimeSlotAsync(TimeSlot timeSlotToUpdate);
        Task<Response<List<TimeSlot>>> GetTimeSlotsAsync();
        Task<Response<TimeSlot>> GetTimeSlotById(Guid timeSlotId);
        Task<Response<bool>> DeleteTimeSlotById(Guid timeSlotId);
    }
}
