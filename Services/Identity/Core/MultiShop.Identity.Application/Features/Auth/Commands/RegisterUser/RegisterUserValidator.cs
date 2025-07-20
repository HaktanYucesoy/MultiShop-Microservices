using FluentValidation;
using MultiShop.Identity.Application.Common.Messages;
using MultiShop.Identity.Application.Common.Regexs;


namespace MultiShop.Identity.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty()
                .WithMessage(UserMessages.USERNAME_CAN_NOT_EMPTY)
                .Length(3, 50).WithMessage(UserMessages.USERNAME_CHARACTER_LIMIT(3, 50))
                .Matches(UserPropertyRegexs.UserNameContainRegex).WithMessage(UserMessages.USERNAME_CAN_ONLY);
        }
    }
}
