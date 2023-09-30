using System;

namespace TimeTracker.Domain.Entities
{
    public class TimeEntry : BaseEntity
    {
        public Guid TimeEntryId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
