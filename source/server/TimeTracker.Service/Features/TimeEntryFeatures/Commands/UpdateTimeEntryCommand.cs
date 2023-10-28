using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeEntryFeatures.Commands
{
    public class UpdateTimeEntryCommand : IRequest<Response<bool>>
    {
        public TimeEntryDto TimeEntryDto { get; set; }

        public class UpdateTimeEntryCommandHandler : IRequestHandler<UpdateTimeEntryCommand, Response<bool>>
        {
            private readonly IMapper _mapper;
            private readonly ITimeEntryService _timeEntryService;
            public UpdateTimeEntryCommandHandler(ITimeEntryService timeEntryService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _timeEntryService = timeEntryService ?? throw new ArgumentNullException(nameof(timeEntryService));
            }
            public async Task<Response<bool>> Handle(UpdateTimeEntryCommand request, CancellationToken cancellationToken)
            {
                var timeEntry = _mapper.Map<TimeEntry>(request.TimeEntryDto);

                if (timeEntry is null)
                {
                    return new Response<bool>
                    {
                        Message = "Invalid object",
                        Succeeded = false
                    };
                }

                return await _timeEntryService.UpdateTimeEntryAsync(timeEntry);
            }
        }
    }
}
