using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task.Core.Features.Orders.Command.Models;
using Task.Core.Features.Orders.Query.Models;
using Task.Data.Models.Identity;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        private string GetUserId() =>
           User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new UnauthorizedAccessException("User ID not found.");
        public OrderController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            this._mediator = mediator;
            this._userManager = userManager;
        }

        [HttpPost("Add-New")]
        public async Task<IActionResult> Create([FromBody] AddNewOrderCommand Command)
        {
            var userId = GetUserId();

            Command.UserId = GetUserId();

            var response = await _mediator.Send(Command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var response = await _mediator.Send(new GetAllOrdersQuery() { UserId = userId });
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
