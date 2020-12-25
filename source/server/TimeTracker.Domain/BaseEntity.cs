using System;

namespace TimeTracker.Domain
{
    public class BaseEntity
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
