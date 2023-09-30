using AutoMapper;
using TimeTracker.Domain.Dtos;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Infrastructure.Mapping
{
    public class TimeEntryProfile : Profile
    {
        public TimeEntryProfile()
        {
            CreateMap<TimeEntryDto, TimeEntry>();
        }
    }
}
