using FluentValidation;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandValidator:AbstractValidator<UpdateAddressCommandRequest>
    {

        public UpdateAddressCommandValidator()
        {
            RuleFor(x=>x.Detail).NotEmpty().WithMessage("Detail is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required")
                .Length(1, 170).WithMessage("City must be between 1 and 170 characters");

            RuleFor(x => x.District).NotEmpty().WithMessage("District is required");
        }
    }
}
