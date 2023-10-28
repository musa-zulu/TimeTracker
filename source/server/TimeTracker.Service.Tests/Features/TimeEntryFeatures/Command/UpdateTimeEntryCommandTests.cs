using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using TimeTracker.Domain.Dtos;
using TimeTracker.Infrastructure.Mapping;
using TimeTracker.Service.Contract;
using TimeTracker.Service.Features.TimeEntryFeatures.Commands;
using TimeTracker.Service.Tests.Common;
using static TimeTracker.Service.Features.TimeEntryFeatures.Commands.UpdateTimeEntryCommand;

namespace TimeTracker.Service.Tests.Features.TimeEntryFeatures.Command;

[TestFixture]
public class UpdateTimeEntryCommandTests
{
    private readonly IMapper _mapper;
    private ITimeEntryService _mockService;
    private readonly TimeEntryDto _timeEntryDto;
    private UpdateTimeEntryCommandHandler _handler;

    public UpdateTimeEntryCommandTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<TimeEntryProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _timeEntryDto = new TimeEntryDto
        {
            TimeEntryId = System.Guid.NewGuid(),
            HoursWorked = 2.3M
        };
    }

    [Test]
    public async Task Handle_GivenAnInvalidTimeEntry_ShouldNotUpdateTimeEntry()
    {
        //---------------Set up test pack-------------------
        _mockService = GetMockService();
        _handler = CreateTimeEntryCommandHandler();
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        var result = await _handler.Handle(new UpdateTimeEntryCommand()
        , cancellationToken: System.Threading.CancellationToken.None);
        //---------------Test Result -----------------------
        result.Succeeded.ShouldBeFalse();
    }

    [Test]
    public async Task Handle_GivenAnInvalidTimeEntry_MessageShouldBeInvalidObject()
    {
        //---------------Set up test pack-------------------
        _mockService = GetMockService();
        _handler = CreateTimeEntryCommandHandler();
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        var result = await _handler.Handle(new UpdateTimeEntryCommand()
        , cancellationToken: System.Threading.CancellationToken.None);
        //---------------Test Result -----------------------
        Assert.AreEqual("Invalid object", result.Message);
    }

    [Test]
    public async Task Handle_GivenATimeEntry_ShouldCallAddTimeEntryAsync()
    {
        //---------------Set up test pack-------------------
        _mockService = GetMockService(1);
        _handler = CreateTimeEntryCommandHandler();
        //---------------Assert Precondition----------------
        //---------------Execute Test ----------------------
        await Handle();
        //---------------Test Result -----------------------
        _ = _mockService.Received(1).UpdateTimeEntryAsync(Arg.Any<Domain.Entities.TimeEntry>());
    }

    private async Task Handle()
    {
        await _handler.Handle(new UpdateTimeEntryCommand()
        {
            TimeEntryDto = _timeEntryDto
        }, cancellationToken: System.Threading.CancellationToken.None);
    }

    private static ITimeEntryService GetMockService(int? timeCount = 0)
    {
        return MockTimeEntryService.GetMockService(timeCount);
    }

    private UpdateTimeEntryCommandHandler CreateTimeEntryCommandHandler()
    {
        return new(_mockService, _mapper);
    }
}
