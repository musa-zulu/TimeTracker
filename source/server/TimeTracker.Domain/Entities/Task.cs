using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class Task : BaseEntity
    {
        public Guid TaskId { get; set; }
        public string Description { get; set; }        
        public virtual List<TimeSlot> TimeSlots { get; set; }
    }
}
