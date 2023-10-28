using System;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Implementation;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}