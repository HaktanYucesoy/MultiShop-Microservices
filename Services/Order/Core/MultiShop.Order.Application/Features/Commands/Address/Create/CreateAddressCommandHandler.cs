using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Create
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        public Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
