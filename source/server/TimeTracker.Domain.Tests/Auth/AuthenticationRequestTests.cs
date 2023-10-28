using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth;

[TestFixture]
public class AuthenticationRequestTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new AuthenticationRequest());
        //---------------Test Result -----------------------
    }

    [TestCase("Email", typeof(string))]
    [TestCase("Password", typeof(string))]
    public void AuthenticationRequest_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(AuthenticationRequest);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}