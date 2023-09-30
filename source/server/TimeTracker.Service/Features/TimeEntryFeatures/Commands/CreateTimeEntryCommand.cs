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
    public class CreateTimeEntryCommand : IRequest<Response<bool>>
    {
        public TimeEntryDto TimeEntryDto { get; set; }

        public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, Response<bool>>
        {
            private readonly IMapper _mapper;
            private readonly ITaskService _taskService;
            private readonly ITimeEntryService _timeEntryService;

            public CreateTimeEntryCommandHandler(ITimeEntryService timeEntryService, ITaskService taskService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
                _timeEntryService = timeEntryService ?? throw new ArgumentNullException(nameof(timeEntryService));
            }

            public async Task<Response<bool>> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
            {
                var timeEntry = _mapper.Map<TimeEntry>(request.TimeEntryDto);
                if (timeEntry == null)
                {
                    return new Response<bool>
                    {
                        Message = "Invalid object",
                        Succeeded = false
                    };
                }

                var task = await _taskService.GetTaskById(timeEntry.TaskId);
                if (!task.Succeeded)
                {
                    return new Response<bool>
                    {
                        Message = "Invalid task object",
                        Succeeded = false
                    };
                }
                timeEntry.TimeEntryId = Guid.NewGuid();
                //timeEntry.UserId = Microsoft.AspNetCore.Mvc.HttpContext.User?.Identity?.Name ?? Guid.Empty; this can't be a name but a user id
                return await _timeEntryService.AddTimeEntryAsync(timeEntry);
            }
        }
    }
}
