using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities
{
    [TestFixture]
    public class TimeSlotTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new TimeSlot());
            //---------------Test Result -----------------------
        }

        [TestCase("TimeSlotId", typeof(Guid))]
        [TestCase("TaskId", typeof(Guid))]
        [TestCase("UserId", typeof(Guid))]
        [TestCase("TaskDescription", typeof(string))]
        [TestCase("WeekNumber", typeof(int))]
        [TestCase("Date", typeof(DateTime))]
        [TestCase("DayDescription", typeof(string))]
        [TestCase("HoursCaptured", typeof(double))]
        [TestCase("Task", typeof(Task))]
        [TestCase("DateCreated", typeof(DateTime))]
        [TestCase("DateUpdated", typeof(DateTime))]
        [TestCase("AddedBy", typeof(string))]
        [TestCase("UpdatedBy", typeof(string))]
        public void TimeSlot_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(TimeSlot);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
