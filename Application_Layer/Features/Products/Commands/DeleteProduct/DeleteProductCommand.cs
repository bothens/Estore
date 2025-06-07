using Application_Layer.Common.Results;
using MediatR;

namespace Application_Layer.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<OperationResult>
    {
        public int ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
