using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
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
            try
            {
                var deleteResponse = await _orderingRepository.DeleteOrderWithDetails(request.Id);
                return new DeleteOrderingCommandResponse()
                {
                    IsSuccess = deleteResponse
                };
            }

            catch(Exception ex)
            {
                throw new DeleteFailureException(nameof(Ordering), request.Id, ex.Message);
            }

        }
    }
}
