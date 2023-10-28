using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Dtos;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TaskFeatures.Commands;

public class UpdateTaskCommand : IRequest<Response<bool>>
{
    public TaskDto TaskDto { get; set; }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<bool>>
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public UpdateTaskCommandHandler(ITaskService taskService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        public async Task<Response<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Domain.Entities.Task>(request.TaskDto);

            return task is null
                ? new Response<bool>
                {
                    Message = "Invalid object",
                    Succeeded = false
                }
                : await _taskService.UpdateTaskAsync(task);
        }
    }
}
