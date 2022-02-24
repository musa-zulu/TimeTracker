using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Infrastructure.Mapping;
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
        private readonly IMapper _mapper;
        private Mock<ITaskService> _mockService;

        public GetAllTasksQueryTests()
        {
            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TaskProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task GetTasksAsync_ShouldBeOfTypeTask()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetTasks(0);
            var handler = new GetAllTasksQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(new GetAllTasksQuery(), 
                cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            result.Should().BeOfType<Response<List<UserTask>>>();
        }

        [Test]
        public async Task GetTasksAsync_GivenNoTasksExists_ShouldReturnEmptyList()
        {
            //---------------Set up test pack-------------------                     
            _mockService = GetTasks(0);
            var handler = new GetAllTasksQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(new GetAllTasksQuery(),
                cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual(0, result.Data.Count);
        }

        private static Mock<ITaskService> GetTasks(int numberOfTasks)
        {
            return MockServices.GetTasks(numberOfTasks);
        }

    }
}
