using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TaskFeatures.Queries;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TaskFeatures.Queries.GetTaskByIdQuery;
using UserTask = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Tests.Features.TaskFeature.Queries
{
    [TestFixture]
    public class GetTaskByIdQueryTests
    {
        private Mock<ITaskService> _mockService;
        [Test]
        public async Task GetTaskByIdAsync_ShouldBeOfTypeTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetTaskById(Guid.Empty);
            var handler = new GetTaskByIdQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(new GetTaskByIdQuery(),
                cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            result.Should().BeOfType<Response<UserTask>>();
        }

        [Test]
        public async Task GetTaskByIdAsync_GivenNoTasksExists_ShouldReturnEmptyResponse()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTaskById(Guid.Empty);
            var handler = new GetTaskByIdQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(new GetTaskByIdQuery(),
                   cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual(Guid.Empty, result.Data.TaskId);
        }

        [Test]
        public async Task GetTaskByIdAsync_GivenATaskExists_ShouldReturnTask()
        {
            //---------------Set up test pack-------------------
            var taskId = Guid.NewGuid();
            _mockService = GetTaskById(taskId);
            var query = new GetTaskByIdQuery
            {
                TaskId = taskId,
            };
            var handler = new GetTaskByIdQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(query,
                              cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual(taskId, result.Data.TaskId);
        }

        private static Mock<ITaskService> GetTaskById(Guid taskId)
        {
            return MockServices.GetTaskById(taskId);
        }
    }
}
