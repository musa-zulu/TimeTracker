using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Common;

namespace TimeTracker.Domain.Tests.Common
{
    [TestFixture]
    public class ResponseTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Response<object>());
            //---------------Test Result -----------------------
        }

        [TestCase("Succeeded", typeof(bool))]
        [TestCase("Message", typeof(string))]
        [TestCase("Errors", typeof(List<string>))]
        [TestCase("Data", typeof(object))]
        public void ApplicationUser_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Response<object>);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }

        [Test]
        public void Construct_GivenMessageIsNull_ShouldReturnTheValuesPassed()
        {
            //---------------Set up test pack-------------------
            var sut = new Response<object>("test", null);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------            
            //---------------Test Result -----------------------
            Assert.AreEqual(sut.Data, "test");
            Assert.AreEqual(sut.Message, null);
            Assert.AreEqual(sut.Succeeded, true);
        }

        [Test]
        public void Construct_GivenMessage_ShouldReturnTheMessage()
        {
            //---------------Set up test pack-------------------
            var sut = new Response<object>("test");
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------            
            //---------------Test Result -----------------------
            Assert.AreEqual(sut.Message, "test");
            Assert.AreEqual(sut.Succeeded, false);
        }
    }
}
