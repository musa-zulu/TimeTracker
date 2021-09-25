using AutoMapper;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Infrastructure.Mapping
{
    public class TimeSlotProfile : Profile
    {
        public TimeSlotProfile()
        {
            CreateMap<TimeSlotDto, TimeSlot>()
                .ForMember(dest => dest.Task, opt =>
                    opt.Ignore());
        }
    }
}
