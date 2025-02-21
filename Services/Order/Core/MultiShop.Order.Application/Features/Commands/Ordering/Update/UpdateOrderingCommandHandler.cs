using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;


namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingCommandResponse>
    {
        private readonly IOrderingRepository _orderingRepository;  
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IOrderingRepository orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }
        public async Task<UpdateOrderingCommandResponse> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {

            var existingOrdering = await _orderingRepository.GetByIdAsync(request.Id);
            if (existingOrdering == null)
                throw new NotFoundException(nameof(Ordering), request.Id);

            try
            {
                var newDeliveryAddress = request.DeliveryAddress;
                var newOrderDetails = request.OrderDetails;
                if (newDeliveryAddress != null)
                {
                    existingOrdering.UpdateDeliveryAddress(newDeliveryAddress.District, newDeliveryAddress.City, newDeliveryAddress.Detail);
                }

                if (newOrderDetails != null)
                {
                    foreach (var orderDetail in newOrderDetails)
                    {
                        existingOrdering.UpdateOrderDetail(orderDetail.Id,
                            orderDetail.ProductAmount,
                            orderDetail.ProductPrice,
                            orderDetail.ProductName,
                            orderDetail.ProductImage);
                    }
                }

                var updatedOrdering = await _orderingRepository.UpdateOrderWithUpdatedToNewOrderDetailsAndAddress(existingOrdering,
                    existingOrdering.OrderDetails.ToList(),existingOrdering.DeliveryAddress);

                return _mapper.Map<UpdateOrderingCommandResponse>(updatedOrdering);


            }
            catch(Exception ex)
            {
                throw new UpdateFailureException(nameof(Ordering), request.Id, ex.Message);
            }
        }
    }
}
