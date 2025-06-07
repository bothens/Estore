using Application_Layer.Dtos.ProductDtos.Validators;
using FluentValidation;

namespace Application_Layer.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId must be greater than zero.");

            RuleFor(x => x.UpdateProductDto)
                .NotNull().WithMessage("UpdateProductDto is required.")
                .SetValidator(new UpdateProductDtoValidator());
        }
    }
}
