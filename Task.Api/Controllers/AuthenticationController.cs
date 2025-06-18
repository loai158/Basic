using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Features.Authentication.Command.Models;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.IsAuthenticated)
                return BadRequest(response.Message);

            return Ok(response);
        }
        [HttpPost("log-in")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.IsAuthenticated)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}
