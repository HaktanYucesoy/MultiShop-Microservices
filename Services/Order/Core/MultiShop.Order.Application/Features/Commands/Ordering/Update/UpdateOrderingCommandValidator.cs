using FluentValidation;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandValidator:AbstractValidator<UpdateOrderingCommandRequest>
    {
        public UpdateOrderingCommandValidator()
        {
            RuleFor(x => x.DeliveryAddress)
                .NotNull().WithMessage("Delivery Address is required")
                .ChildRules(d =>
                {
                    d.RuleFor(da => da!.City).NotNull().NotEmpty().WithMessage("City is required")
                    .Length(1, 170).WithMessage("City must be between 1 and 170 characters");

                    d.RuleFor(da => da!.Detail).NotNull().NotEmpty().WithMessage("Detail is required");

                    d.RuleFor(da => da!.District).NotNull().NotEmpty().WithMessage("District is required");

                });

            RuleFor(x => x.OrderDetails).NotNull().WithMessage("Order Details are required")
                .Must(x => x!.Count > 0).WithMessage("Order Details are required")
                .ForEach(x =>
                {
                    x.ChildRules(od =>
                    {
                        od.RuleFor(od => od!.ProductId).NotNull().NotEmpty().WithMessage("Product is required");
                        od.RuleFor(od=>od!.ProductName).NotNull().NotEmpty().WithMessage("Product Name is required");
                        od.RuleFor(od=>od!.ProductImage).NotNull().NotEmpty().WithMessage("Product Image is required");
                        od.RuleFor(od=>od!.ProductAmount).GreaterThanOrEqualTo(0)
                        .WithMessage("Product Amount must be greater than or equal to 0");
                        od.RuleFor(od=>od!.ProductPrice).GreaterThanOrEqualTo(0)
                        .WithMessage("Product Price must be greater than or equal to 0");
                    });
                });


            RuleFor(x=>x.Id).NotNull().NotEmpty().WithMessage("Order is required");
            
        }
    }
}
