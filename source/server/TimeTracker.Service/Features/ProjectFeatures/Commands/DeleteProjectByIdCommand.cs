using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            private readonly IMapper _mapper;
            public DeleteProjectByIdHandler(IProjectService projectService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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