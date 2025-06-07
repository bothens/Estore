using Application_Layer.Common.Results;
using Application_Layer.Dtos.ProductDtos;
using MediatR;

namespace Application_Layer.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<OperationResult>
    {
        public int ProductId { get; set; }
        public UpdateProductDto UpdateProductDto { get; set; }

        public UpdateProductCommand(int productId, UpdateProductDto updateProductDto)
        {
            ProductId = productId;
            UpdateProductDto = updateProductDto;
        }
    }
}
