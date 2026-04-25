using FluentValidation;
using ProductAPI.Models;

namespace ProductAPI.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100);

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category is required");

            RuleFor(p => p.ImageUrl1)
                .NotEmpty().WithMessage("Main image is required");

            RuleFor(p => p.Description)
                .MaximumLength(500);
        }
    }
}