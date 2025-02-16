using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var deleteResponse=await _orderDetailRepository.DeleteAsync(request.Id);
            return new DeleteOrderDetailCommandResponse()
            {
                IsSuccess = deleteResponse
            };
        }
    }
}
