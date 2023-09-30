using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain.Entities
{
    public class TimeEntry : BaseEntity
    {
        public Guid TimeEntryId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        public Guid TaskId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal HoursWorked { get; set; }
    }
}
