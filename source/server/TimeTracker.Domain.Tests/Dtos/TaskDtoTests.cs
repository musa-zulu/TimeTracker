using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;
using TimeTracker.Domain.Dtos;

namespace TimeTracker.Domain.Tests.Dtos;

[TestFixture]
public class TaskDtoTests
{

    [TestCase("Description", typeof(string))]
    [TestCase("HoursSpent", typeof(double))]
    [TestCase("Date", typeof(DateTime))]
    [TestCase("Billable", typeof(bool))]
    [TestCase("TotalHoursSpent", typeof(double))]
    [TestCase("DayOfTheWeek", typeof(string))]
    [TestCase("TimeEntries", typeof(List<TimeEntryDto>))]
    public void TaskDto_ShouldHaveProperty(string propertyName, Type propertyType)
    {
        //---------------Set up test pack-------------------
        var sut = typeof(TaskDto);
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        sut.ShouldHaveProperty(propertyName, propertyType);
        //---------------Test Result -----------------------
    }
}
