using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeSlotFeatures.Queries
{
    public class GetAllTimeSlotsQuery : IRequest<Response<IEnumerable<TimeSlot>>>
    {
        public class GetAllTimeSlotsQueryHandler : IRequestHandler<GetAllTimeSlotsQuery, Response<IEnumerable<TimeSlot>>>
        {
            private readonly ITimeSlotsService _timeSlotService;
            public GetAllTimeSlotsQueryHandler(ITimeSlotsService timeSlotsService)
            {
                _timeSlotService = timeSlotsService;
            }
            public async Task<Response<IEnumerable<TimeSlot>>> Handle(GetAllTimeSlotsQuery request, CancellationToken cancellationToken)
            {
                var timeSlots = await _timeSlotService.GetAllAsync();
                return timeSlots;
            }
        }
    }
}
