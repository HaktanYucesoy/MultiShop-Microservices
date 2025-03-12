using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {

        private IOrderDetailRepository _orderDetailRepository;
        private IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IOrderingRepository orderingRepository = null)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _orderingRepository = orderingRepository;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var existingOrderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);
            if (existingOrderDetail == null)
                throw new NotFoundException(nameof(OrderDetail), request.Id);


            var order = await _orderingRepository.GetByIdWithIncludesAsync(existingOrderDetail.OrderingId,x=>x.OrderDetails);      

            order.UpdateOrderDetail(request.Id,request.ProductAmount,request.ProductPrice,request.ProductName,request.ProductImage);

            

            var response = await _orderingRepository.UpdateOrderWithUpdatedToOrderDetail(order,existingOrderDetail);

            return _mapper.Map<UpdateOrderDetailCommandResponse>(
                order.OrderDetails.First(x=>x.Id==request.Id));
        }
    }
}
