using AutoMapper;
using MediatR;
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
            var updateResponse = await _orderDetailRepository.UpdateAsync(new Domain.Entities.OrderDetail()
            {
                Id = request.Id,
                ProductId = request.ProductId,
                ProductAmount = request.ProductAmount,
                ProductPrice = request.ProductPrice,
                ProductName = request.ProductName,
                ProductImage = request.ProductImage,
                ProductTotalPrice = request.ProductTotalPrice,
                OrderingId = request.OrderingId
            });

            return _mapper.Map<UpdateOrderDetailCommandResponse>(updateResponse);
        }
    }
}
