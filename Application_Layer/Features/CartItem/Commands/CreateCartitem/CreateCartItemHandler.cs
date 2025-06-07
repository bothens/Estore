using Application_Layer.Commands.CartItemCommands.CreateCartItem;
using Application_Layer.Dtos.CartItemDtos;
using Application_Layer.Dtos;
using Application_Layer.Interfaces.CartItemInterfaces;
using AutoMapper;
using MediatR;
using Application_Layer.Interfaces.ProductInterfaces;
using Application_Layer.Interfaces.UserInterface;
using Domain_Layer.Models;

namespace Application_Layer.Handlers.CartItemHandlers
{
    public class CreateCartItemHandler : IRequestHandler<CreateCartItemCommand, CartItemResponseDto<CartItemDto>>
    {
        private readonly ICartItemRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCartItemHandler(
            ICartItemRepository repository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CartItemResponseDto<CartItemDto>> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            // Kontrollera om produkten finns
            var product = await _productRepository.GetProductByIdAsync(request.Dto.ProductId);
            if (product == null)
                return CartItemResponseDto<CartItemDto>.Fail("Product not found");

            // Kontrollera om användaren finns
            var user = await _userRepository.GetUserByIdAsync(request.Dto.UserId);
            if (user == null)
                return CartItemResponseDto<CartItemDto>.Fail("User not found");

            // Mappa och spara
            var entity = _mapper.Map<CartItem>(request.Dto);
            entity.CartItemId = 0;

            var created = await _repository.CreateCartItemAsync(entity);
            var dto = _mapper.Map<CartItemDto>(created);

            return CartItemResponseDto<CartItemDto>.Ok(dto, "Cart item created successfully");
        }
    }
}
