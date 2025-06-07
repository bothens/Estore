using Application_Layer.Dtos.ProductDtos.Validators;
using FluentValidation;

namespace Application_Layer.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(x => x.CreateProductDto)
                .NotNull().WithMessage("CreateProductDto is required.")
                .SetValidator(new CreateProductDtoValidator());
        }
    }
}
