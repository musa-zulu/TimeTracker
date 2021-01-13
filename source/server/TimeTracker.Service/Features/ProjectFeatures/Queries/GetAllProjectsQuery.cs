using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.ProjectFeatures.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
        public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
        {
            private readonly IProjectService _projectService;
            public GetAllProjectsQueryHandler(IProjectService projectService)
            {
                _projectService = projectService;
            }
            public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
            {
                var projects = await _projectService.GetProjectsAsync();
                if (projects == null)
                {
                    return null;
                }
                return projects?.Data ?? new List<Project>();
            }
        }
    }
}
