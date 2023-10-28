using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using TimeTracker.Domain.Dtos;
using TimeTracker.Infrastructure.Mapping;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TaskFeatures.Commands;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TaskFeatures.Commands.CreateTaskCommand;

namespace TimeTracker.Service.Tests.Features.TaskFeature.Commands
{
    [TestFixture]
    public class CreateTaskCommandTests
    {
        private readonly IMapper _mapper;
        private readonly TaskDto _taskDto;
        private ITaskService _mockService;
        private CreateTaskCommandHandler _handler;

        public CreateTaskCommandTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TaskProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new TaskDto
            {
                TaskId = System.Guid.NewGuid(),
                Description = "New Task"
            };
        }

        [Test]
        public async Task Handle_GivenAnInvalidTask_ShouldNotAddTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService();
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            var result = await _handler.Handle(new CreateTaskCommand()
            , cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            result.Succeeded.ShouldBeFalse();
        }

        [Test]
        public async Task Handle_GivenAnInvalidTask_MessageShouldBeInvalidObject()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService();
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            var result = await _handler.Handle(new CreateTaskCommand()
            , cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual("Invalid object", result.Message);
        }

        [Test]
        public async Task Handle_GivenAValidTask_ShouldAddTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService(1);
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            await Handle();
            var tasks = await _mockService.GetTasksAsync();
            //---------------Test Result -----------------------
            tasks.Data.Count.ShouldBe(1);
        }

        [Test]
        public async Task Handle_GivenAValidTask_ShouldHaveTaskCountOfZero()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService(0);
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            await Handle();
            var tasks = await _mockService.GetTasksAsync();
            //---------------Test Result -----------------------
            tasks.Data.Count.ShouldBe(0);
        }

        [Test]
        public async Task Handle_GivenAValidTask_ShouldCallAddTaskAsync()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService(1);
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            await Handle();
            //---------------Test Result -----------------------
            _ = _mockService.Received(1).AddTaskAsync(Arg.Any<Domain.Entities.Task>());
        }

        private async Task Handle()
        {
            await _handler.Handle(new CreateTaskCommand()
            { TaskDto = _taskDto }, cancellationToken: System.Threading.CancellationToken.None);
        }

        private static ITaskService GetMockService(int? taskCount = 0)
        {
            return MockTaskService.GetMockService(taskCount);
        }

        private CreateTaskCommandHandler CreateTaskCommandHandler()
        {
            return new CreateTaskCommandHandler(_mockService, _mapper);
        }
    }
}
