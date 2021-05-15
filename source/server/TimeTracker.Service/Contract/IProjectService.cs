using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Service.Contract
{
    public interface IProjectService
    {
        Task<Response<bool>> AddProjectAsync(Project newProject);
        Task<Response<bool>> UpdateProjectAsync(Project projectToUpdate);
        Task<Response<List<Project>>> GetProjectsAsync();
        Task<Response<Project>> GetProjectById(Guid projectId);
        Task<Response<bool>> DeleteProjectById(Guid projectId);
    }
}
