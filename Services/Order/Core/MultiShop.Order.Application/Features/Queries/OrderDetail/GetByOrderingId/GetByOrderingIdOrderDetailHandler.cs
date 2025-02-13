using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId
{
    public class GetByOrderingIdOrderDetailHandler : IRequestHandler<GetByOrderingIdOrderDetailQueryRequest, GetByOrderingIdOrderDetailQueryResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public GetByOrderingIdOrderDetailHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<GetByOrderingIdOrderDetailQueryResponse> Handle(GetByOrderingIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetail=await _orderDetailRepository.GetByFilterAsync(x => x.OrderingId == request.OrderingId);

            return _mapper.Map<GetByOrderingIdOrderDetailQueryResponse>(orderDetail);
        }
    }
}
