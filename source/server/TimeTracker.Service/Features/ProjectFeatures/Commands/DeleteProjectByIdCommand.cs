using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.ProjectFeatures.Commands
{
    public class DeleteProjectByIdCommand : IRequest<bool>
    {
        public Guid ProjectId { get; set; }
        public class DeleteProjectByIdHandler : IRequestHandler<DeleteProjectByIdCommand, bool>
        {
            private readonly IProjectService _projectService;            
            public DeleteProjectByIdHandler(IProjectService projectService)
            {                
                _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            }
            public async Task<bool> Handle(DeleteProjectByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _projectService.DeleteProjectById(request.ProjectId);
                return results.Succeeded;
            }
        }
    }
}