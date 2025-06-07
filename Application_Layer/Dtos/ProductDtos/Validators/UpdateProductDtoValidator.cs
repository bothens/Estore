using FluentValidation;

namespace Application_Layer.Dtos.ProductDtos.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                    .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                    .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                    .GreaterThanOrEqualTo(0).When(x => x.Price.HasValue)
                    .WithMessage("Price must be a positive value.");

            RuleFor(x => x.StockQuantity)
                    .GreaterThanOrEqualTo(0).When(x => x.StockQuantity.HasValue)
                    .WithMessage("StockQuantity must be zero or greater.");

            RuleFor(x => x.ImageUrl)
                    .MaximumLength(255).WithMessage("ImageUrl must not exceed 255 characters.");

            RuleFor(x => x.Category)
                    .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
        }
    }
}
