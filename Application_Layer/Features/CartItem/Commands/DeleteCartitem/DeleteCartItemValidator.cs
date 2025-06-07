using FluentValidation;

namespace Application_Layer.Validators.CartItemValidators
{
    public class DeleteCartItemValidator : AbstractValidator<int>
    {
        public DeleteCartItemValidator()
        {
            RuleFor(id => id).GreaterThan(0).WithMessage("Ogiltigt ID");
        }
    }
}
