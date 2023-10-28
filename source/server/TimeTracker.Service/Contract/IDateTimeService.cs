using System;

namespace TimeTracker.Service.Contract;

public interface IDateTimeService
{
    DateTime NowUtc { get; }
}
