using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest, CreateOrderingCommandResponse>
    {
        public Task<CreateOrderingCommandResponse> Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
