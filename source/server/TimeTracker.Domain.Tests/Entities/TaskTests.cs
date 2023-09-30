using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Task());
            //---------------Test Result -----------------------
        }

        [TestCase("TaskId", typeof(Guid))]
        [TestCase("Description", typeof(string))]
        //[TestCase("TotalHoursSpent", typeof(double))]
        //[TestCase("DayOfTheWeek", typeof(string))]
        //[TestCase("Billable", typeof(bool))]
        [TestCase("TimeEntries", typeof(List<TimeEntry>))]
        [TestCase("DateCreated", typeof(DateTime))]
        [TestCase("DateUpdated", typeof(DateTime))]
        [TestCase("AddedBy", typeof(string))]
        [TestCase("UpdatedBy", typeof(string))]
        public void Task_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Task);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
