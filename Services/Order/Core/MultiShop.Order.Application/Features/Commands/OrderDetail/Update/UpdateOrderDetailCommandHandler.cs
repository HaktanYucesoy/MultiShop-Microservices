using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        public Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
