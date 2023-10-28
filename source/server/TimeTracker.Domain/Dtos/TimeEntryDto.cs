using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain.Dtos;

public class TimeEntryDto : BaseEntity
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
