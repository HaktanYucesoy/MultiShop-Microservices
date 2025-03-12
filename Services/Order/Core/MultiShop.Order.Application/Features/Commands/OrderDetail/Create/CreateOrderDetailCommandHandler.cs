using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {

       
        private readonly IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public CreateOrderDetailCommandHandler(IMapper mapper, IOrderingRepository orderingRepository)
        {
            
            _mapper = mapper;
            _orderingRepository = orderingRepository;
        }
        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var ordering = await _orderingRepository.GetByIdWithIncludesAsync(request.OrderingId, x => x.OrderDetails);
            if (ordering == null)
                throw new NotFoundException(nameof(Ordering), request.OrderingId);


            ordering.AddOrderDetail(request.ProductId, request.ProductAmount, request.ProductPrice, request.ProductName, request.ProductImage);

            var savedOrdering=await _orderingRepository.UpdateOrderWithAddedToNewOrderDetail(ordering, ordering.OrderDetails.Last());

            return _mapper.Map<CreateOrderDetailCommandResponse>(savedOrdering.OrderDetails.Last());
        }
    }
}
