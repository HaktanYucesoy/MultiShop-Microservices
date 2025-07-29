using FluentValidation;
using MultiShop.Identity.Application.Common.Messages;
using MultiShop.Identity.Application.Common.Regexs;
using System.Net;

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

            RuleFor(u => u.Email).NotEmpty()
                .WithMessage(UserMessages.EMAIL_CAN_NOT_EMPTY)
                .EmailAddress().WithMessage(UserMessages.INVALID_EMAIL_FORMAT)
                .MaximumLength(255).WithMessage(UserMessages.EMAIL_MAX_CHARACTER_LIMIT(255));

            RuleFor(u=>u.Password).NotEmpty()
                .WithMessage(UserMessages.PASSWORD_IS_REQUIRED)
                .MinimumLength(6).WithMessage(UserMessages.PASSWORD_MIN_CHARACTER_LIMIT(6))
                .Matches(UserPropertyRegexs.PasswordContainRegex).WithMessage(UserMessages.PASSWORD_CAN_ONLY);


            RuleFor(u => u.FirstName).NotEmpty()
                .WithMessage(UserMessages.FIRST_NAME_CAN_NOT_EMPTY)
                .Length(2, 50).WithMessage(UserMessages.NAME_CHARACTER_LIMIT("First name", 2, 50))
                .Matches(UserPropertyRegexs.FirstNameContainRegex).WithMessage(UserMessages.FIRST_NAME_CAN_ONLY);

            RuleFor(u => u.LastName).NotEmpty()
                .WithMessage(UserMessages.LAST_NAME_CAN_NOT_EMPTY)
            .Length(2,50).WithMessage(UserMessages.NAME_CHARACTER_LIMIT("Last name",2,50))
            .Matches(UserPropertyRegexs.LastNameContainRegex).WithMessage(UserMessages.LAST_NAME_CAN_ONLY);

            RuleFor(u => u.IpAddress).NotEmpty()
                .WithMessage(UserMessages.IP_ADDRESS_REQUIRED)
                .Must(BeValidIpAddress).WithMessage(UserMessages.INVALID_IP_ADDRESS);
        }

        private bool BeValidIpAddress(string ipAddress)
        {
            return IPAddress.TryParse(ipAddress, out _);
        }
    }
}
