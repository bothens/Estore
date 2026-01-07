using Application_Layer.Commands.CartItemCommands.CreateCartItem;
using Application_Layer.Dtos;
using Application_Layer.Dtos.CartItemDtos;
using Application_Layer.Interfaces.CartItemInterfaces;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Estore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CartItemsController(
            ICartItemRepository repository,
            IMapper mapper,
            IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repository.GetAllCartItemsAsync();
            var dtos = _mapper.Map<List<CartItemDto>>(items);
            return Ok(dtos);
        }

        // GET: api/cartitems/{id}
        [HttpGet("{id:int}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var item = await _repository.GetCartItemByIdAsync(id);
            if (item == null) return NotFound();
            var dto = _mapper.Map<CartItemDto>(item);
            return Ok(dto);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartItemDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var command = new CreateCartItemCommand(dto);
            var result = await _mediator.Send(command, cancellationToken); 

   
            if (result is CartItemResponseDto<CartItemDto> response)
            {
                if (!response.Success) return BadRequest(response.Message);

                var created = response.Data!;
                return CreatedAtAction(nameof(GetById), new { id = created.CartItemId }, created);
            }

            return StatusCode(500, "No result from handler.");
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CartItemDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var existing = await _repository.GetCartItemByIdAsync(id);
            if (existing == null) return NotFound();

            var toUpdate = _mapper.Map<CartItem>(dto);
            toUpdate.CartItemId = id;

            await _repository.UpdateCartItemAsync(toUpdate);
            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var deleted = await _repository.DeleteCartItemAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}