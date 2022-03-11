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
        public static Mock<ITaskService> GetTasks(int? numberOfTasks)
        {
            var tasks = new List<Task>();
            for (var task = 0; task < numberOfTasks; task++)
            {
                tasks.Add(new Task
                {
                    TaskId = Guid.NewGuid(),
                    Description = "task " + task
                });
            }            
            var tasksResponse = new Response<List<Task>>
            {
                Data = tasks
            };

            var mockService = new Mock<ITaskService>();
            mockService.Setup(x => x.GetTasksAsync()).ReturnsAsync(tasksResponse);            
            return mockService;
        }

        public static Mock<ITaskService> GetTaskById(Guid taskId)
        {
            var tasks = new List<Task>();
            var tasksResponse = new Response<Task>
            {
                Data = new Task
                {
                    TaskId = taskId
                }
            };

            var mockService = new Mock<ITaskService>();            
            mockService.Setup(x => x.GetTaskById(taskId)).ReturnsAsync(tasksResponse);
            return mockService;
        }
    }
}
