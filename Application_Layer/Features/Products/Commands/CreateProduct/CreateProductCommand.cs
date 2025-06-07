using Application_Layer.Common.Results;
using Application_Layer.Dtos.ProductDtos;
using MediatR;

namespace Application_Layer.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand : IRequest<OperationResult>
    {
        public CreateProductDto CreateProductDto { get; }

        public CreateProductCommand(CreateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }
    }
}
