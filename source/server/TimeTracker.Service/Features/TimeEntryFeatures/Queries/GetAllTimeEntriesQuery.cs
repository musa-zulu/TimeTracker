using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeEntryFeatures.Queries;

public class GetAllTimeEntriesQuery : IRequest<Response<List<TimeEntry>>>
{
    public class GetAllTimeEntryQueryHandler : IRequestHandler<GetAllTimeEntriesQuery, Response<List<TimeEntry>>>
    {
        private readonly ITimeEntryService _timeEntryService;
        public GetAllTimeEntryQueryHandler(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }

        public async Task<Response<List<TimeEntry>>> Handle(GetAllTimeEntriesQuery request, CancellationToken cancellationToken)
        {
            return await _timeEntryService.GetTimeEntriesAsync();
        }
    }
}
