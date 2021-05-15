using AutoMapper;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Infrastructure.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, Project>()
                   .ForMember(dest => dest.TimeSlots, opt =>
                    opt.Ignore());
        }
    }
}
