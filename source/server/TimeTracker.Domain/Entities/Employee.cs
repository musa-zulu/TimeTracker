using System;

namespace TimeTracker.Domain.Entities;

public class Employee : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeLastName { get; set; }
    public string EmployeeMaidenName { get; set; }
    public string EmployeeIdNumber { get; set; }
    public string Email { get; set; }
    public string CellNumber { get; set; }
    public string HomeNumber { get; set; }
    public Address PhysicalAddress { get; set; }
    public Address PostalAddress { get; set; }

    public virtual Guid TeamId { get; set; }
    public virtual Team Team { get; set; }
}
