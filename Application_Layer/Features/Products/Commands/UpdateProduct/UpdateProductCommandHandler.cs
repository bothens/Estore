using Application_Layer.Common.Results;
using Application_Layer.Dtos.ProductDtos;
using Application_Layer.Interfaces.ProductInterfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application_Layer.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductByIdAsync(request.ProductId);

                if (existingProduct == null)
                {
                    return OperationResult.Failure($"Product with ID {request.ProductId} not found.");
                }

                _mapper.Map(request.UpdateProductDto, existingProduct);
                await _productRepository.UpdateProductAsync(existingProduct);

                var productResponseDto = _mapper.Map<ProductResponseDto>(existingProduct);
                return OperationResult.SuccessOBJ("Successfully updated product details", productResponseDto);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Failed to update product: {ex.Message}");
            }
        }
    }
}
