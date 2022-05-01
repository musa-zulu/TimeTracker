using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeSlotFeatures.Queries
{
    public class GetAllTimeSlotsQuery : IRequest<Response<List<TimeSlot>>>
    {
        public class GetAllTimeSlotsQueryHandler : IRequestHandler<GetAllTimeSlotsQuery, Response<List<TimeSlot>>>
        {
            private readonly ITimeSlotsService _timeSlotService;
            public GetAllTimeSlotsQueryHandler(ITimeSlotsService timeSlotsService)
            {
                _timeSlotService = timeSlotsService;
            }
            public async Task<Response<List<TimeSlot>>> Handle(GetAllTimeSlotsQuery request, CancellationToken cancellationToken)
            {
                var timeSlots = await _timeSlotService.GetTimeSlotsAsync();
                return timeSlots;
            }
        }
    }
}
