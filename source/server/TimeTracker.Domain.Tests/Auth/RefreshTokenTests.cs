using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth
{
    [TestFixture]
    public class RefreshTokenTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new RefreshToken());
            //---------------Test Result -----------------------
        }

        [TestCase("Id", typeof(int))]
        [TestCase("Token", typeof(string))]
        [TestCase("Expires", typeof(DateTime))]
        [TestCase("IsExpired", typeof(bool))]
        [TestCase("Created", typeof(DateTime))]
        [TestCase("CreatedByIp", typeof(string))]
        [TestCase("Revoked", typeof(DateTime?))]
        [TestCase("RevokedByIp", typeof(string))]
        [TestCase("ReplacedByToken", typeof(string))]
        [TestCase("IsActive", typeof(bool))]
        public void RefreshToken_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(RefreshToken);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }

    }
}
