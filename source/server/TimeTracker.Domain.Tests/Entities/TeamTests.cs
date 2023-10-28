using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities;

[TestFixture]
public class TeamTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new Team());
        //---------------Test Result -----------------------
    }

    [TestCase("TeamId", typeof(Guid))]
    [TestCase("Name", typeof(string))]
    [TestCase("Description", typeof(string))]
    [TestCase("Employees", typeof(List<Employee>))]
    [TestCase("DateCreated", typeof(DateTime))]
    [TestCase("DateUpdated", typeof(DateTime))]
    [TestCase("AddedBy", typeof(string))]
    [TestCase("UpdatedBy", typeof(string))]
    public void Team_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(Team);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
