using MediatR;
using MultiShop.Identity.Application.Helpers.Hashing;
using MultiShop.Identity.Application.Interfaces.Repositories.User;
using MultiShop.Identity.Application.Interfaces.UnitOfWork;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitofWork;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitofWork)
        {
            _userRepository = userRepository;
            _unitofWork = unitofWork;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await CheckUserExistsAsync(request.UserName, request.Email);
            if (userExists)
            {
                return new RegisterUserCommandResponse
                {
                    IsSuccess = false
                };
            }

            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User()
            {
                PasswordHash = passwordHash,
                UserName = request.UserName,
                FirstName= request.FirstName,
                LastName = request.LastName,
                PasswordSalt = passwordSalt,
                Status = true
            };

            newUser.Email = request.Email;
            newUser.AuthenticatorType = Domain.Enums.AuthenticatorType.None;

            await _unitofWork.ExecuteInTransactionAsync(async (ct) =>
            {
                await _userRepository.InsertAsync(newUser);
            });

            var isSuccess = newUser.Id != 0 || !String.IsNullOrEmpty(newUser.Id.ToString());

            return new RegisterUserCommandResponse
            {
                IsSuccess = isSuccess
            };
        }


        private async Task<bool> CheckUserExistsAsync(string userName, string email)
        {
           
            var entity=await _userRepository.GetByFilterAsync(u => u.UserName == userName);
            return entity != null;
        }
    }
}
