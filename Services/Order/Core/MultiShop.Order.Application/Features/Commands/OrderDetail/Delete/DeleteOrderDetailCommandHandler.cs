using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderingRepository _orderingRepository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IOrderingRepository orderingRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderingRepository = orderingRepository;
        }
        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var existOrderDetail=await _orderDetailRepository.GetByIdAsync(request.Id);
            if (existOrderDetail == null)
            {
                return new DeleteOrderDetailCommandResponse()
                {
                    IsSuccess = false
                };
            }

            var existOrdering=await _orderingRepository.GetByIdWithIncludesAsync(existOrderDetail.OrderingId,x=>x.OrderDetails);

            if(existOrdering==null)
            {
                return new DeleteOrderDetailCommandResponse()
                {
                    IsSuccess = false
                };
            }

            existOrdering.DeleteOrderDetail(existOrderDetail.Id);

            var response=await _orderingRepository.UpdateOrderByDeleteOrderDetail(existOrderDetail, existOrdering);

            return new DeleteOrderDetailCommandResponse()
            {
                IsSuccess = response
            };



        }
    }
}
