using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeEntryFeatures.Queries;

public class GetTimeEntryByIdQuery : IRequest<Response<TimeEntry>>
{
    public Guid TimeEntryId { get; set; }
    public class GetTimeEntryByIdQueryHandler : IRequestHandler<GetTimeEntryByIdQuery, Response<TimeEntry>>
    {
        private readonly ITimeEntryService _timeEntryService;
        public GetTimeEntryByIdQueryHandler(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }
        public async Task<Response<TimeEntry>> Handle(GetTimeEntryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _timeEntryService.GetTimeEntryById(request.TimeEntryId);
        }
    }
}