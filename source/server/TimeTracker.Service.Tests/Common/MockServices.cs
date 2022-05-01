using NSubstitute;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Tests.Common
{
    public static class MockServices
    {
        public static ITaskService GetTasks(int? numberOfTasks)
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

            var mockService = Substitute.For<ITaskService>();
            mockService.GetTasksAsync().Returns(tasksResponse);
            return mockService;
        }

        public static ITaskService GetTaskById(Guid taskId)
        {            
            var tasksResponse = new Response<Task>
            {
                Data = new Task
                {
                    TaskId = taskId
                }
            };

            var mockService = Substitute.For<ITaskService>();
            mockService.GetTaskById(taskId).Returns(tasksResponse);
            return mockService;
        }

        public static ITaskService GetMockService(int? taskCount)
        {
            var mockService = GetTasks(taskCount);
            return mockService;
        }
    }
}
