using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth;

[TestFixture]
public class ResetPasswordRequestTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new ResetPasswordRequest());
        //---------------Test Result -----------------------
    }

    [TestCase("Email", typeof(string))]
    [TestCase("Token", typeof(string))]
    [TestCase("Password", typeof(string))]
    [TestCase("ConfirmPassword", typeof(string))]
    public void ResetPasswordRequest_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(ResetPasswordRequest);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
