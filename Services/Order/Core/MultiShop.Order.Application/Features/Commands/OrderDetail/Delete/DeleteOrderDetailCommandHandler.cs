using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        public Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
