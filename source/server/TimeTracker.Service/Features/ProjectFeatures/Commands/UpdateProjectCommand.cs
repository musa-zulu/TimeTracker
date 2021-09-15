using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Features.ProjectFeatures.Commands
{
    public class UpdateProjectCommand : IRequest<bool>
    {
        public ProjectDto ProjectDto { get; set; }

        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
        {
            private readonly IProjectService _projectService;
            private readonly IMapper _mapper;
            public UpdateProjectCommandHandler(IProjectService projectService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            }
            public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
            {
                var project = _mapper.Map<Project>(request.ProjectDto);
                var projectUpdated = false;
                if (project != null)
                {
                    var results = await _projectService.UpdateProjectAsync(project);
                    projectUpdated = results.Succeeded;
                }
                return projectUpdated;
            }
        }
    }
}
