using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Features.Products.Command.Models;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Add-New")]
        public async Task<IActionResult> Create([FromBody] AddNewProductCommand Command)
        {
            var response = await _mediator.Send(Command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

    }
}
