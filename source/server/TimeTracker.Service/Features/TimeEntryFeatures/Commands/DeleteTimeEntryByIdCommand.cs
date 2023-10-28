using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeEntryFeatures.Commands;

public class DeleteTimeEntryByIdCommand : IRequest<Response<bool>>
{
    public Guid TimeEntryId { get; set; }

    public class DeleteTimeEntryByIdCommandHandler : IRequestHandler<DeleteTimeEntryByIdCommand, Response<bool>>
    {
        private readonly ITimeEntryService _timeEntryService;
        public DeleteTimeEntryByIdCommandHandler(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService ?? throw new ArgumentNullException(nameof(timeEntryService));
        }
        public async Task<Response<bool>> Handle(DeleteTimeEntryByIdCommand request, CancellationToken cancellationToken)
        {
            return await _timeEntryService.DeleteTimeEntryById(request.TimeEntryId);
        }
    }
}
