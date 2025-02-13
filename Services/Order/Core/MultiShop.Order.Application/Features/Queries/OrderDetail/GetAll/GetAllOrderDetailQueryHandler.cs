using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, List<GetAllOrderDetailQueryResponse>>
    {

        private readonly IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public GetAllOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllOrderDetailQueryResponse>> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var allOrderDetails = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<List<GetAllOrderDetailQueryResponse>>(allOrderDetails);
        }
    }
}
