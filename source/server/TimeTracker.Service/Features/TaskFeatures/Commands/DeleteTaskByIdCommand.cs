using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.TaskFeatures.Commands
{
    public class DeleteTaskByIdCommand : IRequest<Response<bool>>
    {
        public Guid TaskId { get; set; }
        public class DeleteTaskByIdHandler : IRequestHandler<DeleteTaskByIdCommand, Response<bool>>
        {
            private readonly ITaskService _taskService;
            public DeleteTaskByIdHandler(ITaskService taskService)
            {
                _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
            }
            public async Task<Response<bool>> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
            {
                return await _taskService.DeleteTaskById(request.TaskId);
            }
        }
    }
}