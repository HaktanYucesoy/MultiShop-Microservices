using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Rules.OrderDetail;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {

       
        private OrderDetailBusinessRules _orderDetailBusinessRules;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IOrderingRepository orderingRepository, OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _orderingRepository = orderingRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var existingOrderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);
            _orderDetailBusinessRules.CannotDeleteOrUpdateToIfNotExistOrderDetail(existingOrderDetail);

            var order = await _orderingRepository.GetByIdWithIncludesAsync(existingOrderDetail.OrderingId,x=>x.OrderDetails);
            order.UpdateOrderDetail(request.Id,request.ProductAmount,request.ProductPrice,request.ProductName,request.ProductImage);

            var response = await _orderingRepository.UpdateOrderWithUpdatedToOrderDetail(order,existingOrderDetail);

            return _mapper.Map<UpdateOrderDetailCommandResponse>(
                order.OrderDetails.First(x=>x.Id==request.Id));
        }
    }
}
