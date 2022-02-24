using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Tests.Entities
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Employee());
            //---------------Test Result -----------------------
        }

        [TestCase("EmployeeId", typeof(Guid))]
        [TestCase("EmployeeName", typeof(string))]
        [TestCase("EmployeeLastName", typeof(string))]
        [TestCase("EmployeeMaidenName", typeof(string))]
        [TestCase("EmployeeIdNumber", typeof(string))]
        [TestCase("Email", typeof(string))]
        [TestCase("CellNumber", typeof(string))]
        [TestCase("HomeNumber", typeof(string))]
        [TestCase("PhysicalAddress", typeof(Address))]
        [TestCase("PostalAddress", typeof(Address))]
        [TestCase("TeamId", typeof(Guid))]
        [TestCase("Team", typeof(Team))]
        [TestCase("DateCreated", typeof(DateTime))]
        [TestCase("DateUpdated", typeof(DateTime))]
        [TestCase("AddedBy", typeof(string))]
        [TestCase("UpdatedBy", typeof(string))]
        public void Employee_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Employee);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);
            //---------------Test Result -----------------------
        }
    }
}