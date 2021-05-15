using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TimeTracker.Service.Features.ProjectFeatures.Commands;
using TimeTracker.Service.Features.ProjectFeatures.Queries;

namespace TimeTracker.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Project")]
    [ApiVersion("1.0")]
    public class ProjectController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator
        {
            get { return _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); }
            set
            {
                if (_mediator != null) throw new InvalidOperationException("Mediator is already set");
                _mediator = value;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetById(Guid projectId)
        {
            return Ok(await Mediator.Send(new GetProjectByIdQuery { ProjectId = projectId }));
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(Guid projectId)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { ProjectId = projectId }));
        }

    }
}
