using System;
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities;

public class Team : BaseEntity
{
    public Guid TeamId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Employee> Employees { get; set; }
}
