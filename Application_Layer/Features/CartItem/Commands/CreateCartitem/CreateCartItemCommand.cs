using Application_Layer.Dtos.CartItemDtos;
using Application_Layer.Dtos;
using MediatR;

namespace Application_Layer.Commands.CartItemCommands.CreateCartItem
{
    public class CreateCartItemCommand : IRequest<CartItemResponseDto<CartItemDto>>
    {
        public CartItemDto Dto { get; }

        public CreateCartItemCommand(CartItemDto dto)
        {
            Dto = dto;
        }
    }
}