using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Persistence;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProjectService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<bool>> AddProjectAsync(Project newProject)
        {
            try
            {
                await _applicationDbContext.Projects.AddAsync(newProject);
                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
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

        public async Task<Response<bool>> DeleteProjectById(Guid projectId)
        {
            try
            {
                var project = await GetProjectById(projectId);
                if (project == null) throw new ArgumentNullException(nameof(project));
                DeleteProjectDetailsFrom(project.Data);
                _applicationDbContext.Projects.Remove(project.Data);
                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
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

        private void DeleteProjectDetailsFrom(Project project)
        {
            var timeSlots = project?.TimeSlots;
            if (timeSlots != null && timeSlots.Count > 0)
            {
                foreach (var timeSlot in timeSlots)
                    _applicationDbContext.TimeSlots.Remove(timeSlot);
            }
        }

        public async Task<Response<Project>> GetProjectById(Guid projectId)
        {
            try
            {
                var project = await _applicationDbContext
                                      .Projects
                                      .Include(x => x.TimeSlots)
                                      .FirstOrDefaultAsync(x => x.ProjectId == projectId);

                return new Response<Project>
                {
                    Data = project,
                    Message = null
                };
            }
            catch (Exception e)
            {
                return new Response<Project>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<List<Project>>> GetProjectsAsync()
        {
            try
            {
                var projects = await _applicationDbContext
                    .Projects
                    .Include(c => c.TimeSlots)
                    .ToListAsync();

                return new Response<List<Project>>
                {
                    Data = projects,
                    Message = null
                };
            }
            catch (Exception e)
            {
                return new Response<List<Project>>
                {
                    Data = null,
                    Message = e.Message
                };
            }
        }

        public async Task<Response<bool>> UpdateProjectAsync(Project projectToUpdate)
        {
            try
            {
                var project = _applicationDbContext.Projects.Update(projectToUpdate);

                return new Response<bool>
                {
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
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
