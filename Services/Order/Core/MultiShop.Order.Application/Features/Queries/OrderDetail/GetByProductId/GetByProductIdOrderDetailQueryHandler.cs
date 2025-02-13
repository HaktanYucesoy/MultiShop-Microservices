using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByProductId
{
    public class GetByProductIdOrderDetailQueryHandler : IRequestHandler<GetByProductIdOrderDetailQueryRequest, GetByProductIdOrderDetailQueryResponse>
    {

        private readonly IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public GetByProductIdOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<GetByProductIdOrderDetailQueryResponse> Handle(GetByProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetail=await _orderDetailRepository.GetByFilterAsync(x => x.ProductId == request.ProductId);

            return _mapper.Map<GetByProductIdOrderDetailQueryResponse>(orderDetail);
        }
    }
}
