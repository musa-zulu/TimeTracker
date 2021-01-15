using System;
using System.Text.Json.Serialization;

namespace TimeTracker.Domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        public Guid TimeSlotId { get; set; }        
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string TaskDescription { get; set; }
        public int WeekNumber { get; set; }
        public DateTime Date { get; set; }
        public string DayDescription { get; set; }
        public double HoursCaptured { get; set; }  
        
        [JsonIgnore]
        public Project Project { get; set; }
    }
}  
