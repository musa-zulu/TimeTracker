using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Dtos;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TaskFeatures.Commands;

public class CreateTaskCommand : IRequest<Response<bool>>
{
    public TaskDto TaskDto { get; set; }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<bool>>
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskService taskService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        public async Task<Response<bool>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Domain.Entities.Task>(request.TaskDto);

            if (task is null)
            {
                return new Response<bool>
                {
                    Message = "Invalid object",
                    Succeeded = false
                };
            }
            task.TaskId = Guid.NewGuid();

            return await _taskService.AddTaskAsync(task);
        }
    }
}
