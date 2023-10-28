using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Contract;

public interface ITaskService
{
    Task<Response<bool>> AddTaskAsync(Task newTask);
    Task<Response<bool>> UpdateTaskAsync(Task taskToUpdate);
    Task<Response<List<Task>>> GetTasksAsync();
    Task<Response<Task>> GetTaskById(Guid taskId);
    Task<Response<bool>> DeleteTaskById(Guid taskId);
}
