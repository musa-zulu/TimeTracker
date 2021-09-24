using System;

namespace TimeTracker.Domain.Entities
{
    public class Task : BaseEntity
    {
        public Guid TaskId { get; set; }
        public string Description { get; set; }
        public double HoursSpent { get; set; }
        public DateTime Date { get; set; }
        public bool Billable { get; set; }
        public double TotalHoursSpent { get; set; }
        public string DayOfTheWeek { get; set; }
    }
}
