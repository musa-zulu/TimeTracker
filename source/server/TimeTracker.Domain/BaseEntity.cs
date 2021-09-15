using System;

namespace TimeTracker.Domain
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
