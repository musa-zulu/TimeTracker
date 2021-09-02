using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Dtos;

namespace TimeTracker.Domain.Tests.Dtos
{
    [TestFixture]
    public class ProjectDtoTests
    {
        [TestCase("ProjectId", typeof(Guid))]
        [TestCase("Description", typeof(string))]
        [TestCase("TotalHours", typeof(double))]
        [TestCase("TotalBillableHours", typeof(double))]
        [TestCase("TimeSlots", typeof(List<TimeSlotDto>))]
        public void ProjectDto_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(ProjectDto);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }

    }
}
