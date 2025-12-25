Estore\Controllers\ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application_Layer.Dtos.ProductDtos;
using Application_Layer.Commands.ProductCommands.CreateProduct;
using Application_Layer.Common.Results;
using System.Threading.Tasks;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                return BadRequest("CreateProductDto is required.");

            var command = new CreateProductCommand(createProductDto);
            var result = await _mediator.Send(command);

            if (result == null)
                return StatusCode(500, "No result from handler.");

            if (result.IsSuccess)
            {
                // return created with the created object (frontend can inspect)
                return Created(string.Empty, result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}