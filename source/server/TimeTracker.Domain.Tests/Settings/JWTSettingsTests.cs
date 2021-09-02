using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Settings;

namespace TimeTracker.Domain.Tests.Settings
{
    [TestFixture]
    public class JWTSettingsTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new JWTSettings());
            //---------------Test Result -----------------------
        }

        [TestCase("Key", typeof(string))]
        [TestCase("Issuer", typeof(string))]
        [TestCase("Audience", typeof(string))]
        [TestCase("DurationInMinutes", typeof(double))]
        public void JWTSettings_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(JWTSettings);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
