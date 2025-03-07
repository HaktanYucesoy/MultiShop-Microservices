using FluentValidation;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandValidator:AbstractValidator<CreateOrderDetailCommandRequest>
    {
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().NotNull().WithMessage("Product Name is required");

            RuleFor(x => x.ProductPrice)
                .GreaterThan(0).WithMessage("Product Price must be greater than zero");

            RuleFor(x => x.ProductImage)
                .NotNull().NotEmpty().WithMessage("Product Image is required");

            RuleFor(x=>x.ProductAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Product Amount must be greater than or equal to zero");

            RuleFor(x => x.OrderingId)
                .NotEmpty().NotNull().WithMessage("Ordering is required");

        }
    }
}
