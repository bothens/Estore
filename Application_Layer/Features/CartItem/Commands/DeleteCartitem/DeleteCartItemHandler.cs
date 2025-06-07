using Application_Layer.Commands.CartItemCommands.DeleteCartItem;
using Application_Layer.Dtos.CartItemDtos;
using Application_Layer.Dtos;
using Application_Layer.Interfaces.CartItemInterfaces;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;

namespace Application_Layer.Handlers.CartItemHandlers
{
    public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, CartItemResponseDto<bool>>
    {
        private readonly ICartItemRepository _repo;

        public DeleteCartItemHandler(ICartItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<CartItemResponseDto<bool>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repo.DeleteCartItemAsync(request.Id);

            if (!deleted)
                return CartItemResponseDto<bool>.Fail("Item not found.");

            return CartItemResponseDto<bool>.Ok(true, "Deleted successfully.");
        }
    }
}
