using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {

        private IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var existingOrderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);
            if (existingOrderDetail == null)
                throw new NotFoundException(nameof(OrderDetail), request.Id);

            existingOrderDetail.UpdateDetails(
                request.ProductAmount,
                request.ProductPrice,
                request.ProductName,
                request.ProductImage,
                request.OrderingId
            );


            var updatedOrderDetail = await _orderDetailRepository.UpdateAsync(existingOrderDetail);
            return _mapper.Map<UpdateOrderDetailCommandResponse>(updatedOrderDetail);
        }
    }
}
