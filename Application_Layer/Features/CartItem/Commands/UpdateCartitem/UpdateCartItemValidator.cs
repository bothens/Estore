using Application_Layer.Dtos.CartItemDtos;
using FluentValidation;

namespace Application_Layer.Validators.CartItemValidators
{
    public class UpdateCartItemValidator : AbstractValidator<CartItemDto>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
