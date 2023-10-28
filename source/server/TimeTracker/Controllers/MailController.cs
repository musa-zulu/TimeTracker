using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.Domain.Settings;
using TimeTracker.Service.Contract;

namespace TimeTracker.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/Mail")]
[ApiVersion("1.0")]
public class MailController : ControllerBase
{
    private readonly IEmailService _mailService;
    public MailController(IEmailService mailService)
    {
        this._mailService = mailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm] MailRequest request)
    {
        await _mailService.SendEmailAsync(request);
        return Ok();
    }
}