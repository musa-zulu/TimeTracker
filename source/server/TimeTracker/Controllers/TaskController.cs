using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TimeTracker.Service.Features.TaskFeatures.Commands;
using TimeTracker.Service.Features.TaskFeatures.Queries;

namespace TimeTracker.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/Task")]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class TaskController : ControllerBase
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
    [Route("Create")]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllTasksQuery()));
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(Guid taskId)
    {
        return Ok(await Mediator.Send(new GetTaskByIdQuery { TaskId = taskId }));
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Guid taskId)
    {
        return Ok(await Mediator.Send(new DeleteTaskByIdCommand { TaskId = taskId }));
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update(Guid taskId, UpdateTaskCommand command)
    {
        if (taskId != command.TaskDto.TaskId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }

}
