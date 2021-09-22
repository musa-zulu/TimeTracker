using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Dtos;

namespace TimeTracker.Domain.Tests.Dtos
{
    [TestFixture]
    public class TimeSlotDtoTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new TimeSlotDto());
            //---------------Test Result -----------------------
        }

        [TestCase("TimeSlotId", typeof(Guid))]
        [TestCase("ProjectId", typeof(Guid))]
        [TestCase("UserId", typeof(Guid))]
        [TestCase("TaskDescription", typeof(string))]
        [TestCase("WeekNumber", typeof(int))]
        [TestCase("Date", typeof(DateTime))]
        [TestCase("DayDescription", typeof(string))]
        [TestCase("HoursCaptured", typeof(double))]
        [TestCase("Project", typeof(ProjectDto))]
        public void TimeSlotDto_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(TimeSlotDto);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
