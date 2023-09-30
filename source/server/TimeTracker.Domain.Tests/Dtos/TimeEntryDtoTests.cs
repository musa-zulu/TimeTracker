using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Dtos;

namespace TimeTracker.Domain.Tests.Dtos
{
    [TestFixture]
    public class TimeEntryDtoTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new TimeEntryDto());
            //---------------Test Result -----------------------
        }

        [TestCase("TimeEntryId", typeof(Guid))]
        [TestCase("TaskId", typeof(Guid))]
        [TestCase("ProjectId", typeof(Guid))]
        [TestCase("UserId", typeof(Guid))]
        [TestCase("Date", typeof(DateTime))]
        [TestCase("HoursWorked", typeof(decimal))]
        public void TimeEntryDto_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(TimeEntryDto);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
