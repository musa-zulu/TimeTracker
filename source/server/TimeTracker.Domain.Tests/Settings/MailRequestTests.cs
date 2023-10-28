using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Settings;

namespace TimeTracker.Domain.Tests.Settings;

[TestFixture]
public class MailRequestTests
{
    [Test]
    public void Construct()
    {
        //---------------Set up test pack-------------------
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        Assert.DoesNotThrow(() => new MailRequest());
        //---------------Test Result -----------------------
    }

    [TestCase("ToEmail", typeof(string))]
    [TestCase("Subject", typeof(string))]
    [TestCase("Body", typeof(string))]
    [TestCase("From", typeof(string))]
    public void MailRequest_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(MailRequest);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}

