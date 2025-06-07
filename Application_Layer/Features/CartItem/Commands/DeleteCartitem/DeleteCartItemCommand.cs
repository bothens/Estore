using MediatR;

using Application_Layer.Dtos;

namespace Application_Layer.Commands.CartItemCommands.DeleteCartItem
{
    public class DeleteCartItemCommand : IRequest<CartItemResponseDto<bool>>
    {
        public int Id { get; }

        public DeleteCartItemCommand(int id)
        {
            Id = id;
        }
    }
}
