using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities
{
    [TestFixture]
    public class TimeEntryTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new TimeEntry());
            //---------------Test Result -----------------------
        }

        [TestCase("TimeEntryId", typeof(Guid))]
        [TestCase("ProjectId", typeof(Guid))]
        [TestCase("UserId", typeof(Guid))]
        [TestCase("Date", typeof(DateTime))]
        [TestCase("HoursWorked", typeof(decimal))]
        [TestCase("DateCreated", typeof(DateTime))]
        [TestCase("DateUpdated", typeof(DateTime))]
        [TestCase("AddedBy", typeof(string))]
        [TestCase("UpdatedBy", typeof(string))]
        public void TimeEntry_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(TimeEntry);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
