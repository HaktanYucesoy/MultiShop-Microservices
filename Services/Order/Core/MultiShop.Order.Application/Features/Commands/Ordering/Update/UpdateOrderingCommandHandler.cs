using MediatR;


namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingCommandResponse>
    {
        public Task<UpdateOrderingCommandResponse> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
