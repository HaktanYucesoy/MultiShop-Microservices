using MediatR;
using MultiShop.Order.Application.Features.Rules.OrderDetail;
using MultiShop.Order.Application.Features.Rules.Ordering;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderingRepository _orderingRepository;
        private readonly OrderDetailBusinessRules _businessRules;
        private readonly OrderingBusinessRules _orderingBusinessRules;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IOrderingRepository orderingRepository, OrderDetailBusinessRules businessRules, OrderingBusinessRules orderingBusinessRules)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderingRepository = orderingRepository;
            _businessRules = businessRules;
            _orderingBusinessRules = orderingBusinessRules;
        }
        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var existOrderDetail=await _orderDetailRepository.GetByIdAsync(request.Id);       
            _businessRules.CannotDeleteOrUpdateToIfNotExistOrderDetail(existOrderDetail);

            var existOrdering=await _orderingRepository.GetByIdWithIncludesAsync(existOrderDetail.OrderingId,x=>x.OrderDetails);
            _orderingBusinessRules.CannotDeleteOrUpdateToIfNotExistOrdering(existOrdering);
            existOrdering.DeleteOrderDetail(existOrderDetail.Id);

            var response=await _orderingRepository.UpdateOrderByDeleteOrderDetail(existOrderDetail, existOrdering);

            return new DeleteOrderDetailCommandResponse()
            {
                IsSuccess = response
            };



        }
    }
}
