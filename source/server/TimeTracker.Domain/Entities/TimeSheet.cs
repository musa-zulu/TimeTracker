using System;
using System.Collections.Generic;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Entities
{
    public class TimeSheet : BaseEntity
    {
        public Guid TimeSheetId { get; set; }

        public bool Submitted { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}  
