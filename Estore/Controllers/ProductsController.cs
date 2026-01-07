using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application_Layer.Dtos.ProductDtos;
using Application_Layer.Interfaces.ProductInterfaces;
using AutoMapper;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createDto, CancellationToken cancellationToken = default)
        {
            if (createDto == null) return BadRequest("CreateProductDto is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var product = _mapper.Map<Product>(createDto);
            var saved = await _repository.AddProductAsync(product);

            // Try to map back to a response DTO if one exists; otherwise return the saved entity
            object response = saved;
            try
            {
                var mapped = _mapper.Map<object>(saved);
                response = mapped ?? saved;
            }
            catch
            {
                // ignore mapping failures here and return domain object
            }

            return CreatedAtAction(nameof(GetById), new { id = saved.ProductId }, response);
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id:int}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateProductDto updateDto, CancellationToken cancellationToken = default)
        {
            if (updateDto == null) return BadRequest("Update payload is required.");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var exists = await _repository.ProductExistsAsync(id);
            if (!exists) return NotFound();

            var product = _mapper.Map<Product>(updateDto);
            product.ProductId = id;
            await _repository.UpdateProductAsync(product);

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var removed = await _repository.RemoveProductAsync(id);
            if (removed == null) return NotFound();
            return NoContent();
        }
    }
}