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

namespace TimeTracker.Service.Tests.Features.TaskFeature.Queries
{
    [TestFixture]
    public class GetAllTasksQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITaskService> _mockService;

        public GetAllTasksQueryTests()
        {
            _mockService = MockServices.GetTasks();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TaskProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task GetTasksAsync_ShouldBeOfType_Task()
        {
            //---------------Set up test pack-------------------  
            var handler = new GetAllTasksQueryHandler(_mockService.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = await handler.Handle(new GetAllTasksQuery(), 
                cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            result.Should().BeOfType<Response<List<Domain.Entities.Task>>>();
        }

    }
}
