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
        private ITaskService _mockService;
        [Test]
        public async Task GetTaskByIdAsync_ShouldBeOfTypeTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetTaskById(Guid.Empty);
            var handler = new GetTaskByIdQueryHandler(_mockService);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<UserTask> result = await Handle(new GetTaskByIdQuery(), handler);
            //---------------Test Result -----------------------
            result.Should().BeOfType<Response<UserTask>>();
        }

        [Test]
        public async Task GetTaskByIdAsync_GivenNoTasksExists_ShouldReturnEmptyResponse()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTaskById(Guid.Empty);
            var handler = new GetTaskByIdQueryHandler(_mockService);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<UserTask> result = await Handle(new GetTaskByIdQuery(), handler);
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
            var handler = new GetTaskByIdQueryHandler(_mockService);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<UserTask> result = await Handle(query, handler);
            //---------------Test Result -----------------------
            Assert.AreEqual(taskId, result.Data.TaskId);
        }

        private static async Task<Response<UserTask>> Handle(GetTaskByIdQuery query, GetTaskByIdQueryHandler handler)
        {
            return await handler.Handle(query,
                              cancellationToken: System.Threading.CancellationToken.None);
        }

        private static ITaskService GetTaskById(Guid taskId)
        {
            return MockTaskService.GetTaskById(taskId);
        }
    }
}
