using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Auth;

namespace TimeTracker.Domain.Tests.Auth
{
    [TestFixture]
    public class ApplicationUserTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new ApplicationUser());
            //---------------Test Result -----------------------
        }

        [TestCase("FirstName", typeof(string))]
        [TestCase("LastName", typeof(string))]
        [TestCase("RefreshTokens", typeof(List<RefreshToken>))]
        public void ApplicationUser_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(ApplicationUser);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }

        [Test]
        public void OwnsToken_GivenTokenDoesNotExist_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var sut = new ApplicationUser();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = sut.OwnsToken("");
            //---------------Test Result -----------------------
            Assert.IsFalse(results);
        }

        [Test]
        public void OwnsToken_GivenTokenExists_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var token = Guid.NewGuid().ToString();
            var sut = new ApplicationUser
            {
                RefreshTokens = new List<RefreshToken>
                {
                    new RefreshToken
                    {
                        Token = token
                    }
                }
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = sut.OwnsToken(token);
            //---------------Test Result -----------------------
            Assert.IsTrue(results);
        }
    }
}
