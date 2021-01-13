using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual IEnumerable<TimeSlotDto> TimeSlots { get; set; }
    }
}
