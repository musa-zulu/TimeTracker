using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class TimeSheet : BaseEntity
    {
        public Guid TimeSheetId { get; set; }
        public Guid UserId { get; set; }
        public bool Submitted { get; set; }
        public double Total { get; set; }
        public virtual List<TimeSlot> TimeSlots { get; set; }
    }
}
