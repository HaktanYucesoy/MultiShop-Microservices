using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Delete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        public Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
