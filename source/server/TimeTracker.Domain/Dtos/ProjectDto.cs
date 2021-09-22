using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Dtos
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        //sum of all hours spent on all tasks for a given day
        public double TotalHours { get; set; }
        //sum of all hours for a task for a given week
        public double TotalBillableHours { get; set; }
        public virtual List<TimeSlotDto> TimeSlots { get; set; }
    }
}
