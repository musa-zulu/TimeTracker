using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Settings;

namespace TimeTracker.Domain.Tests.Settings
{
    [TestFixture]
    public class MailSettingsTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new MailSettings());
            //---------------Test Result -----------------------
        }

        [TestCase("EmailFrom", typeof(string))]
        [TestCase("SmtpHost", typeof(string))]
        [TestCase("SmtpPort", typeof(int))]
        [TestCase("SmtpUser", typeof(string))]
        [TestCase("SmtpPass", typeof(string))]
        [TestCase("DisplayName", typeof(string))]
        public void MailSettings_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(MailSettings);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
