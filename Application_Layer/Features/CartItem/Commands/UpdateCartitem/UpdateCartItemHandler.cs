using Application_Layer.Dtos.CartItemDtos;
using MediatR;
using FluentValidation;
using Application_Layer.Dtos;
using Application_Layer.Interfaces.CartItemInterfaces;
using AutoMapper;
using Application_Layer.Commands.CartItemCommands.UpdateCartItem.Application_Layer.Commands.CartItemCommands.UpdateCartItem;

namespace Application_Layer.Handlers.CartItemHandlers
{
    public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommand, CartItemResponseDto<CartItemDto>>
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CartItemDto> _validator;

        public UpdateCartItemHandler(ICartItemRepository repository, IMapper mapper, IValidator<CartItemDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CartItemResponseDto<CartItemDto>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            // ✅ Validering av DTO med FluentValidation
            var validationResult = await _validator.ValidateAsync(request.Dto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return CartItemResponseDto<CartItemDto>.Fail("not found.");
            }

            // Hämta existerande entitet från databasen
            var existing = await _repository.GetCartItemByIdAsync(request.Id);
            if (existing == null)
                return CartItemResponseDto<CartItemDto>.Fail("Cart item not found.");

            // Uppdatera värden
            existing.Quantity = request.Dto.Quantity;
            existing.ProductId = request.Dto.ProductId;
            existing.UserId = request.Dto.UserId;

            // Spara ändringar
            await _repository.UpdateCartItemAsync(existing);

            var dto = _mapper.Map<CartItemDto>(existing);
            return CartItemResponseDto<CartItemDto>.Ok(dto, "Cart item updated.");
        }
    }
}