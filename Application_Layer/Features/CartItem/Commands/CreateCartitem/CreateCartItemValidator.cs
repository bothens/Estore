using Application_Layer.Dtos.CartItemDtos;
using FluentValidation;

namespace Application_Layer.Validators.CartItemValidators
{
    public class CreateCartItemValidator : AbstractValidator<CartItemDto>
    {
        public CreateCartItemValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId krävs");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId krävs");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Antal måste vara minst 1");
        }
    }
}
