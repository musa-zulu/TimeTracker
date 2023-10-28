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
using static TimeTracker.Service.Features.TimeEntryFeatures.Commands.CreateTimeEntryCommand;

namespace TimeTracker.Service.Tests.Features.TimeEntryFeatures.Command
{
    [TestFixture]
    public class CreateTimeEntryCommandTests
    {
        private readonly IMapper _mapper;
        private readonly TimeEntryDto _timeEntryDto;
        private ITimeEntryService _mockService;
        private CreateTimeEntryCommandHandler _handler;

        public CreateTimeEntryCommandTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TimeEntryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _timeEntryDto = new TimeEntryDto
            {
                TimeEntryId = System.Guid.NewGuid(),
                HoursWorked = 3.2M
            };
        }

        [Test]
        public async Task Handle_GivenAnInvalidTimeEntry_ShouldNotAddTimeEntry()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService();
            _handler = CreateTimeEntryCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            var result = await _handler.Handle(new CreateTimeEntryCommand()
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
            var result = await _handler.Handle(new CreateTimeEntryCommand()
            , cancellationToken: System.Threading.CancellationToken.None);
            //---------------Test Result -----------------------
            Assert.AreEqual("Invalid object", result.Message);
        }

        [Test]
        public async Task Handle_GivenAValidTimeEntry_ShouldAddTimeEntry()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService(1);
            _handler = CreateTimeEntryCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            await Handle();
            var timeEntries = await _mockService.GetTimeEntriesAsync();
            //---------------Test Result -----------------------
            timeEntries.Data.Count.ShouldBe(1);
        }

        [Test]
        public async Task Handle_GivenAValidEntry_ShouldCallAddTimeEntryAsync()
        {
            //---------------Set up test pack-------------------  
            _mockService = GetMockService(1);
            _handler = CreateTimeEntryCommandHandler();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------           
            await Handle();
            //---------------Test Result -----------------------
            _ = _mockService.Received(1).AddTimeEntryAsync(Arg.Any<Domain.Entities.TimeEntry>());
        }

        private async Task Handle()
            => await _handler.Handle(new CreateTimeEntryCommand()
            {
                TimeEntryDto = _timeEntryDto
            }, cancellationToken: System.Threading.CancellationToken.None);

        private static ITimeEntryService GetMockService(int? timeEntryCount = 0)
        {
            return MockTimeEntryService.GetMockService(timeEntryCount);
        }

        private CreateTimeEntryCommandHandler CreateTimeEntryCommandHandler()
        {
            return new CreateTimeEntryCommandHandler(_mockService, _mapper);
        }
    }
}