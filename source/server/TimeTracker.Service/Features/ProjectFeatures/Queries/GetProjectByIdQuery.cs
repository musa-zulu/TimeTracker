using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.ProjectFeatures.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public Guid ProjectId { get; set; }
        public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
        {
            private readonly IProjectService _projectService;
            public GetProjectByIdQueryHandler(IProjectService projectService)
            {
                _projectService = projectService;
            }
            public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
            {
                var project = await _projectService.GetProjectById(request.ProjectId);
                if (project == null)
                {
                    return null;
                }
                return project.Data;
            }
        }
    }
}
