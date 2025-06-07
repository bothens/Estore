using Application_Layer.Common.Results;
using Application_Layer.Dtos.ProductDtos;
using Application_Layer.Interfaces.ProductInterfaces;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application_Layer.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request.CreateProductDto);
                var savedProduct = await _productRepository.AddProductAsync(product);

                var productResponseDto = _mapper.Map<ProductResponseDto>(savedProduct);

                return OperationResult.SuccessOBJ("Successfully created Product", productResponseDto);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error: {ex.Message}");
            }
        }
    }
}
