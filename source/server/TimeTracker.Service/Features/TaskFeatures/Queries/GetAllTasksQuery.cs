using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Features.TaskFeatures.Queries
{
    public class GetAllTasksQuery : IRequest<Response<List<Task>>>
    {
        public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Response<List<Task>>>
        {
            private readonly ITaskService _taskService;
            public GetAllTasksQueryHandler(ITaskService taskService)
            {
                _taskService = taskService;
            }
            public async Task<Response<List<Task>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
            {
                return await _taskService.GetTasksAsync(); ;
            }
        }
    }
}
