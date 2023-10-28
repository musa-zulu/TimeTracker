using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Features.TaskFeatures.Queries;

public class GetTaskByIdQuery : IRequest<Response<Task>>
{
    public Guid TaskId { get; set; }
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<Task>>
    {
        private readonly ITaskService _taskService;
        public GetTaskByIdQueryHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public async Task<Response<Task>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskService.GetTaskById(request.TaskId);
        }
    }
}
