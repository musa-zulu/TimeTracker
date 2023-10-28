using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TaskFeatures.Commands;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TaskFeatures.Commands.DeleteTaskByIdCommand;

namespace TimeTracker.Service.Tests.Features.TaskFeature.Commands;

[TestFixture]
public class DeleteTaskByIdCommandTests
{
    private ITaskService? _mockService;
    private DeleteTaskByIdHandler? _handler;

    [Test]
    public async Task Handle_GivenAValidTask_ShouldCallDeleteTaskAsync()
    {
        //---------------Set up test pack-------------------
        _mockService = GetMockService(1);
        _handler = CreateTaskCommandHandler();
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        await Handle();
        //---------------Test Result -----------------------
        _ = _mockService.Received(1).DeleteTaskById(System.Guid.Empty);
    }

    private async Task Handle()
    {
        await _handler.Handle(new DeleteTaskByIdCommand()
        { TaskId = System.Guid.Empty }, cancellationToken: System.Threading.CancellationToken.None);
    }

    private static ITaskService GetMockService(int? taskCount = 0)
    {
        return MockTaskService.GetMockService(taskCount);
    }

    private DeleteTaskByIdHandler CreateTaskCommandHandler()
    {
        return new DeleteTaskByIdHandler(_mockService);
    }
}
