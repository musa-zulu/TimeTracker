using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth;

[TestFixture]
public class AuthenticationResponseTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new AuthenticationResponse());
        //---------------Test Result -----------------------
    }

    [TestCase("Id", typeof(string))]
    [TestCase("UserName", typeof(string))]
    [TestCase("Email", typeof(string))]
    [TestCase("Roles", typeof(List<string>))]
    [TestCase("IsVerified", typeof(bool))]
    [TestCase("JWToken", typeof(string))]
    [TestCase("RefreshToken", typeof(string))]
    public void AuthenticationResponse_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(AuthenticationResponse);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
