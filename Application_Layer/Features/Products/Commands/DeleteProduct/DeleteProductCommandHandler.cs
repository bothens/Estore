using Application_Layer.Common.Results;
using Application_Layer.Dtos.ProductDtos;
using Application_Layer.Interfaces.ProductInterfaces;
using AutoMapper;
using MediatR;

namespace Application_Layer.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _productRepository.RemoveProductAsync(request.ProductId);

            if (deletedProduct == null)
            {
                return OperationResult.Failure($"Product with ID {request.ProductId} not found.");
            }

            var dto = _mapper.Map<ProductResponseDto>(deletedProduct);
            return OperationResult.SuccessOBJ("Product deleted successfully.", dto);
        }
    }
}


