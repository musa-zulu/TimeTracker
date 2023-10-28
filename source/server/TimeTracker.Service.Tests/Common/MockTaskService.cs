using NSubstitute;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Tests.Common;

public static class MockTaskService
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

public static class MockTimeEntryService
{
    public static ITimeEntryService GetTimeEntries(int? numberOfEntries)
    {
        var entries = new List<TimeEntry>();
        for (var entry = 0; entry < numberOfEntries; entry++)
        {
            entries.Add(new TimeEntry
            {
                TimeEntryId = Guid.NewGuid(),
                HoursWorked = 2.3M
            });
        }
        var timeEntriesResponse = new Response<List<TimeEntry>>
        {
            Data = entries
        };

        var mockService = Substitute.For<ITimeEntryService>();
        mockService.GetTimeEntriesAsync().Returns(timeEntriesResponse);
        return mockService;
    }

    public static ITimeEntryService GetTimeEntryById(Guid timeEntryId)
    {
        var timeEntriesResponse = new Response<TimeEntry>
        {
            Data = new TimeEntry
            {
                TimeEntryId = timeEntryId
            }
        };

        var mockService = Substitute.For<ITimeEntryService>();
        mockService.GetTimeEntryById(timeEntryId).Returns(timeEntriesResponse);
        return mockService;
    }

    public static ITimeEntryService GetMockService(int? timeEntryCount)
    {
        var mockService = GetTimeEntries(timeEntryCount);
        return mockService;
    }
}