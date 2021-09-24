using System;

namespace TimeTracker.Domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        public Guid TimeSlotId { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string TaskDescription { get; set; }
        public int WeekNumber { get; set; }
        public DateTime Date { get; set; }
        public string DayDescription { get; set; }
        public double HoursCaptured { get; set; }
        public virtual Task Task { get; set; }
    }
}
