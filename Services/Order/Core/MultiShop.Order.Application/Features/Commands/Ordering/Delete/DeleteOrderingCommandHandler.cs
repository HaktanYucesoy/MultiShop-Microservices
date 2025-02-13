using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Delete
{
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommandRequest, DeleteOrderingCommandResponse>
    {
        public Task<DeleteOrderingCommandResponse> Handle(DeleteOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
