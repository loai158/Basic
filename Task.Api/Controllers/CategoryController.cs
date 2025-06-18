using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Features.Categories.Command.Models;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Add-New")]
        public async Task<IActionResult> Create([FromBody] AddNewCategoryCommand Command)
        {
            var response = await _mediator.Send(Command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
