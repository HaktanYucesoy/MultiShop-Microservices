using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        public Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
