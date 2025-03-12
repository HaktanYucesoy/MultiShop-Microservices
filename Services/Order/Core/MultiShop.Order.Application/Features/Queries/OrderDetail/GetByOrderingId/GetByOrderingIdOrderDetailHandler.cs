using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId
{
    public class GetByOrderingIdOrderDetailHandler : IRequestHandler<GetByOrderingIdOrderDetailQueryRequest, IReadOnlyList<GetByOrderingIdOrderDetailQueryResponse>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public GetByOrderingIdOrderDetailHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetByOrderingIdOrderDetailQueryResponse>> Handle(GetByOrderingIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetails=await _orderDetailRepository.GetListByFilterAsync(x => x.OrderingId == request.OrderingId);

            return _mapper.Map<IReadOnlyList<GetByOrderingIdOrderDetailQueryResponse>>(orderDetails);
        }
    }
}
