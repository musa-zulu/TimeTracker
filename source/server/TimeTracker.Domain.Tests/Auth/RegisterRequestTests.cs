using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth;

[TestFixture]
public class RegisterRequestTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new RegisterRequest());
        //---------------Test Result -----------------------
    }

    [TestCase("FirstName", typeof(string))]
    [TestCase("LastName", typeof(string))]
    [TestCase("Email", typeof(string))]
    [TestCase("UserName", typeof(string))]
    [TestCase("Password", typeof(string))]
    [TestCase("ConfirmPassword", typeof(string))]
    public void RegisterRequest_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(RegisterRequest);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
