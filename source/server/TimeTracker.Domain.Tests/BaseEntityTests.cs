using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;

namespace TimeTracker.Domain.Tests;

[TestFixture]
public class BaseEntityTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new BaseEntity());
        //---------------Test Result -----------------------
    }

    [TestCase("DateCreated", typeof(DateTime))]
    [TestCase("DateUpdated", typeof(DateTime))]
    [TestCase("AddedBy", typeof(string))]
    [TestCase("UpdatedBy", typeof(string))]
    public void BaseEntity_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(BaseEntity);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
