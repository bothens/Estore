
using Application_Layer.Dtos.UserDto;
using Application_Layer.Interfaces.UserInterface;
using AutoMapper;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var users = await _repository.GetAllUsersAsync();
            var dtos = _mapper.Map<List<UserResponseDto>>(users);
            return Ok(dtos);
        }

        // GET: api/users/{id}
        [HttpGet("{id:int}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            var dto = _mapper.Map<UserResponseDto>(user);
            return Ok(dto);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserResponseDto createDto, CancellationToken cancellationToken = default)
        {
            if (createDto == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            // Map DTO -> Domain
            var entity = _mapper.Map<User>(createDto);
            // Ensure id is zero for creation
            entity.UserId = 0;

            var created = await _repository.AddUserAsync(entity);
            var createdDto = _mapper.Map<UserResponseDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, createdDto);
        }

        // PUT: api/users/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserResponseDto updateDto, CancellationToken cancellationToken = default)
        {
            if (updateDto == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var exists = await _repository.UserExistsAsync(id);
            if (!exists) return NotFound();

            var toUpdate = _mapper.Map<User>(updateDto);
            toUpdate.UserId = id;

            var ok = await _repository.UpdateUserAsync(toUpdate);
            if (!ok) return BadRequest("Failed to update user.");

            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var removed = await _repository.RemoveUserAsync(id);
            if (removed == null) return NotFound();

            return NoContent();
        }
    }
}