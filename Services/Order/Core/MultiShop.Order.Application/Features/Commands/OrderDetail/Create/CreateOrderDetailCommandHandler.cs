using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Rules.Ordering;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        private readonly IOrderingRepository _orderingRepository;
        private readonly OrderingBusinessRules _orderingBusinessRules;
        private IMapper _mapper;

        public CreateOrderDetailCommandHandler(IMapper mapper,
            IOrderingRepository orderingRepository, 
            OrderingBusinessRules orderingBusinessRules)
        {

            _mapper = mapper;
            _orderingRepository = orderingRepository;
            _orderingBusinessRules = orderingBusinessRules;
        }
        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            var ordering = await _orderingRepository.GetByIdWithIncludesAsync(request.OrderingId, x => x.OrderDetails);   
            _orderingBusinessRules.CannotDeleteOrUpdateToIfNotExistOrdering(ordering);

            ordering.AddOrderDetail(request.ProductId, request.ProductAmount, request.ProductPrice, request.ProductName, request.ProductImage);

            var savedOrdering=await _orderingRepository.UpdateOrderWithAddedToNewOrderDetail(ordering, ordering.OrderDetails.Last());

            return _mapper.Map<CreateOrderDetailCommandResponse>(savedOrdering.OrderDetails.Last());
        }
    }
}
