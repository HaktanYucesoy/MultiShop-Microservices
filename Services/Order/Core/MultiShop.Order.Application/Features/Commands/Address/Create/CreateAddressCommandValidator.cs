using FluentValidation;

namespace MultiShop.Order.Application.Features.Commands.Address.Create
{
    public class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommandRequest>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.City)
                .NotNull().NotEmpty().WithMessage("City is required")
                .Length(1, 170).WithMessage("City must be between 1 and 170 characters");             

            RuleFor(x => x.Detail).NotNull().NotEmpty()
                .WithMessage("Detail is required");

            RuleFor(x => x.District).NotNull().NotEmpty()
                .WithMessage("District is required");
        }
    }
}
