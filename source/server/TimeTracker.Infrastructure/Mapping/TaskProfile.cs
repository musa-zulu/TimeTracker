using AutoMapper;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Infrastructure.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto, Task>().ReverseMap();
        }
    }
}
