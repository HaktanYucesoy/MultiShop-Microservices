using FluentValidation;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandValidator : AbstractValidator<CreateOrderingCommandRequest>
    {
        public CreateOrderingCommandValidator()
        {
            RuleFor(x=>x.DeliveryAddressId).NotNull().NotEmpty()
                .WithMessage("Delivery address is required");
        }
    }
}
