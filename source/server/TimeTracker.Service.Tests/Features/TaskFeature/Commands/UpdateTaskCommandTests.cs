﻿using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using TimeTracker.Domain.Dtos;
using TimeTracker.Infrastructure.Mapping;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TaskFeatures.Commands;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TaskFeatures.Commands.UpdateTaskCommand;

namespace TimeTracker.Service.Tests.Features.TaskFeature.Commands
{
    [TestFixture]
    public class UpdateTaskCommandTests
    {
        private readonly IMapper _mapper;
        private readonly TaskDto _taskDto;
        private ITaskService _mockService;
        private UpdateTaskCommandHandler _handler;

        public UpdateTaskCommandTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TaskProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new TaskDto
            {
                TaskId = System.Guid.NewGuid(),
                Description = "updated task"
            };
        }

        [Test]
        public async Task Handle_GivenAnInvalidTask_ShouldNotUpdateTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService();
            _handler = CreateTaskCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            var result = await _handler.Handle(new UpdateTaskCommand()
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
            var result = await _handler.Handle(new UpdateTaskCommand()
            , cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual("Invalid object", result.Message);
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
            _ = _mockService.Received(1).UpdateTaskAsync(Arg.Any<Domain.Entities.Task>());
        }

        private async Task Handle()
        {
            await _handler.Handle(new UpdateTaskCommand()
            { TaskDto = _taskDto }, cancellationToken: System.Threading.CancellationToken.None);
        }

        private static ITaskService GetMockService(int? taskCount = 0)
        {
            return MockServices.GetMockService(taskCount);
        }

        private UpdateTaskCommandHandler CreateTaskCommandHandler()
        {
            return new UpdateTaskCommandHandler(_mockService, _mapper);
        }
    }
}