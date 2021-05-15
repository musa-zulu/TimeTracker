using System;

namespace TimeTracker.Domain.Dtos
{
    public class TimeSlotDto : BaseEntity
    {
        public Guid TimeSlotId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }        
        public string TaskDescription { get; set; }
        public int WeekNumber { get; set; }
        public DateTime Date { get; set; }
        public string DayDescription { get; set; }
        public double HoursCaptured { get; set; }        
        public ProjectDto Project { get; set; }
    }
}
