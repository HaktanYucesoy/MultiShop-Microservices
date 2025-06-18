using MediatR;


namespace MultiShop.Identity.Application.Features.Auth.Commands.RegisterUser
{
    public sealed record RegisterUserCommand(string UserName,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string IpAddress) : IRequest<RegisterUserCommandResponse>;

}
