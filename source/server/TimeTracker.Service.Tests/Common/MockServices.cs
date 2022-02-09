using Moq;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Tests.Common
{
    public static class MockServices
    {
        public static Mock<ITaskService> GetTasks()
        {
            var tasks = new List<Task>
            {
                new Task
                {
                    TaskId = Guid.NewGuid(),
                    Description = "new task"
                }
            };
            var tasksResponse = new Response<List<Task>>
            {
                Data = tasks
            };

            var mockService = new Mock<ITaskService>();
            mockService.Setup(x => x.GetTasksAsync()).ReturnsAsync(tasksResponse);
            //mockService.Setup(x => x.AddTaskAsync(It.IsAny<Task>()))
            //    .Returns(Task.FromResult(true));

            return mockService;
        }
    }
}
