using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Persistence;
using TimeTracker.Service.Contract;
using Task = TimeTracker.Domain.Entities.Task;

namespace TimeTracker.Service.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public TaskService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Response<bool>> AddTaskAsync(Task newTask)
        {
            try
            {
                await _applicationDbContext.Tasks.AddAsync(newTask);
                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Task has been successfully added"
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> DeleteTaskById(Guid taskId)
        {
            try
            {
                var task = await GetTaskById(taskId);
                if (task == null) throw new ArgumentNullException(nameof(task));

                if (task.Data?.TimeEntries != null)
                    DeleteTaskDetailsFrom(task.Data);

                _applicationDbContext.Tasks.Remove(task.Data);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Object deleted successfully!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }

        private void DeleteTaskDetailsFrom(Task task)
        {
            var timeEntries = task?.TimeEntries;
            if (timeEntries != null && timeEntries.Count > 0)
            {
                foreach (var timeEntry in timeEntries)
                    _applicationDbContext.TimeEntries.Remove(timeEntry);
            }
        }

        public async Task<Response<Task>> GetTaskById(Guid taskId)
        {
            try
            {
                var task = await _applicationDbContext
                                      .Tasks
                                      .FirstOrDefaultAsync(x => x.TaskId == taskId);

                return new Response<Task>
                {
                    Succeeded = true,
                    Data = task,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<Task>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<List<Task>>> GetTasksAsync()
        {
            try
            {
                var tasks = await _applicationDbContext
                    .Tasks
                    .ToListAsync();

                return new Response<List<Task>>
                {
                    Succeeded = true,
                    Data = tasks,
                    Message = "Data successfully retrieved!!!"
                };
            }
            catch (Exception e)
            {
                return new Response<List<Task>>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> UpdateTaskAsync(Task taskToUpdate)
        {
            try
            {
                var task = _applicationDbContext.Tasks.Update(taskToUpdate);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0,
                    Message = "Data has been updated successfully!!"
                };
            }
            catch (Exception e)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = e.Message
                };
            }
        }
    }
}
