using System;
using System.Collections.Generic;
using TimeTracker.Domain.Attributes;

namespace TimeTracker.Domain.Dtos
{
    public class TaskDto : BaseEntity
    {
        public Guid TaskId { get; set; }
        public string Description { get; set; }
        public double HoursSpent { get; set; }
        public DateTime Date { get; set; }
        public bool Billable { get; set; }

        //sum of all hours spent on all tasks for a given day
        public double TotalHoursSpent { get; set; }
        public string DayOfTheWeek { get; set; }
        [SwaggerIgnore]
        public List<TimeEntryDto> TimeEntries { get; set; }
    }
}
