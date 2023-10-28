using System;

namespace TimeTracker.Domain.Entities;

public class Address : BaseEntity
{
    public Guid AddressId { get; set; }
    public int StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string AddressLineOne { get; set; }
    public string AddressLineTwo { get; set; }
    public string AddressLineThree { get; set; }
    public int AreaCode { get; set; }
    public bool IsPhysicalAddress { get; set; }
    public bool IsPostalAddress { get; set; }
}
