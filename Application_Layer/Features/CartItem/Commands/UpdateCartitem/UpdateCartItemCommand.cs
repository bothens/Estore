using Application_Layer.Dtos;
using Application_Layer.Dtos.CartItemDtos;
using MediatR;

namespace Application_Layer.Commands.CartItemCommands.UpdateCartItem
{

    namespace Application_Layer.Commands.CartItemCommands.UpdateCartItem
    {
        public class UpdateCartItemCommand : IRequest<CartItemResponseDto<CartItemDto>>
        {
            public int Id { get; set; }
            public CartItemDto Dto { get; set; }

            public UpdateCartItemCommand(int id, CartItemDto dto)
            {
                Id = id;
                Dto = dto;
            }
        }
    }
}
