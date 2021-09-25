using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TimeSlotFeatures.Commands
{
    public class CreateTimeSlotCommand : IRequest<Response<bool>>
    {
        public TimeSlotDto TimeSlotDto { get; set; }

        public class CreateTimeSlotCommandHandler : IRequestHandler<CreateTimeSlotCommand, Response<bool>>
        {
            private readonly IMapper _mapper;
            private readonly ITaskService _taskService;
            private readonly ITimeSlotsService _timeSlotsService;

            public CreateTimeSlotCommandHandler(ITimeSlotsService timeSlotsService, ITaskService taskService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
                _timeSlotsService = timeSlotsService ?? throw new ArgumentNullException(nameof(timeSlotsService));
            }

            public async Task<Response<bool>> Handle(CreateTimeSlotCommand request, CancellationToken cancellationToken)
            {
                var timeSlot = _mapper.Map<TimeSlot>(request.TimeSlotDto);
                if (timeSlot == null)
                {
                    return new Response<bool>
                    {
                        Message = "Invalid object",
                        Succeeded = false
                    };
                }

                var task = await _taskService.GetTaskById(timeSlot.TaskId);
                if (!task.Succeeded)
                {
                    return new Response<bool>
                    {
                        Message = "Invalid task object",
                        Succeeded = false
                    };
                }
                timeSlot.TimeSlotId = Guid.NewGuid();
                //timeSlot.UserId = Microsoft.AspNetCore.Mvc.HttpContext.User?.Identity?.Name ?? Guid.Empty; this can't be a name but a user id
                return await _timeSlotsService.AddAsync(timeSlot);
            }
        }
    }
}
