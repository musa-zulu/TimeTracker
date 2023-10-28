using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TaskFeatures.Queries;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TaskFeatures.Queries.GetAllTasksQuery;
using UserTask = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Tests.Features.TaskFeature.Queries
{
    [TestFixture]
    public class GetAllTasksQueryTests
    {        
        private ITaskService _mockService;
        [Test]
        public async Task GetTasksAsync_ShouldBeOfTypeTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetTasks(0);
            var handler = GetAllTasksQueryHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<List<UserTask>> result = await Handle(handler);
            //---------------Test Result -----------------------
            result.Should().BeOfType<Response<List<UserTask>>>();
        }

        [Test]
        public async Task GetTasksAsync_GivenNoTasksExists_ShouldReturnEmptyList()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTasks(0);
            var handler = GetAllTasksQueryHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<List<UserTask>> result = await Handle(handler);
            //---------------Test Result -----------------------
            Assert.AreEqual(0, result.Data.Count);
        }

        [Test]
        public async Task GetTasksAsync_GivenOneTaskExists_ShouldReturnTask()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTasks(1);
            var handler = GetAllTasksQueryHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<List<UserTask>> result = await Handle(handler);
            //---------------Test Result -----------------------
            Assert.AreEqual(1, result.Data.Count);
        }

        [Test]
        public async Task GetTasksAsync_GivenTwoTasksExists_ShouldReturnThoseTasks()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTasks(2);
            var handler = GetAllTasksQueryHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<List<UserTask>> result = await Handle(handler);
            //---------------Test Result -----------------------
            Assert.AreEqual(2, result.Data.Count);
        }

        [Test]
        public async Task GetTasksAsync_GivenManyTasksExists_ShouldReturnThoseTasks()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTasks(3);
            var handler = GetAllTasksQueryHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Response<List<UserTask>> result = await Handle(handler);
            //---------------Test Result -----------------------
            Assert.AreEqual(3, result.Data.Count);
        }

        private static async Task<Response<List<UserTask>>> Handle(GetAllTasksQueryHandler handler)
        {           
            return await handler.Handle(new GetAllTasksQuery(),
                cancellationToken: System.Threading.CancellationToken.None);
        }

        private GetAllTasksQueryHandler GetAllTasksQueryHandler()
        {
            return new GetAllTasksQueryHandler(_mockService);
        }

        private static ITaskService GetTasks(int numberOfTasks)
        {
            return MockTaskService.GetTasks(numberOfTasks);
        }

    }
}
