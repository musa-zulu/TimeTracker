using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Project());
            //---------------Test Result -----------------------
        }

        [TestCase("ProjectId", typeof(Guid))]
        [TestCase("Description", typeof(string))]
        [TestCase("TotalHours", typeof(double))]
        [TestCase("TotalBillableHours", typeof(double))]
        [TestCase("TimeSlots", typeof(List<TimeSlot>))]
        [TestCase("DateAdded", typeof(DateTime))]
        [TestCase("DateUpdated", typeof(DateTime))]
        [TestCase("AddedBy", typeof(string))]
        [TestCase("UpdatedBy", typeof(string))]
        public void Project_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Project);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}
