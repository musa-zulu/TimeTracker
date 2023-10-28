using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities;

[TestFixture]
public class AddressTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new Address());
        //---------------Test Result -----------------------
    }

    [TestCase("AddressId", typeof(Guid))]
    [TestCase("StreetNumber", typeof(int))]
    [TestCase("StreetName", typeof(string))]
    [TestCase("AddressLineOne", typeof(string))]
    [TestCase("AddressLineTwo", typeof(string))]
    [TestCase("AddressLineThree", typeof(string))]
    [TestCase("AreaCode", typeof(int))]
    [TestCase("IsPhysicalAddress", typeof(bool))]
    [TestCase("IsPostalAddress", typeof(bool))]
    [TestCase("DateCreated", typeof(DateTime))]
    [TestCase("DateUpdated", typeof(DateTime))]
    [TestCase("AddedBy", typeof(string))]
    [TestCase("UpdatedBy", typeof(string))]
    public void Address_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(Address);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
