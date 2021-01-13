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
    public class CreateProjectCommand : IRequest<bool>
    {
        public ProjectDto ProjectDto { get; set; }

        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, bool>
        {
            private readonly IProjectService _projectService;
            private readonly IMapper _mapper;
            public CreateProjectCommandHandler(IProjectService projectService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            }
            public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                var project = _mapper.Map<Project>(request.ProjectDto);
                var projectSaved = false;
                if (project != null)
                {
                    projectSaved =  _projectService.AddProjectAsync(project).Result.Succeeded;
                }
                return projectSaved;
            }           
        }
    }    
}
