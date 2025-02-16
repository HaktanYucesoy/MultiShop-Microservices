using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Delete
{
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommandRequest, DeleteOrderingCommandResponse>
    {

        private readonly IOrderingRepository _orderingRepository;

        public DeleteOrderingCommandHandler(IOrderingRepository orderingRepository)
        {
            this._orderingRepository = orderingRepository;
        }

        public async Task<DeleteOrderingCommandResponse> Handle(DeleteOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteResponse = await _orderingRepository.DeleteAsync(request.Id);
            return new DeleteOrderingCommandResponse()
            {
                IsSuccess = deleteResponse
            };
        }
    }
}
