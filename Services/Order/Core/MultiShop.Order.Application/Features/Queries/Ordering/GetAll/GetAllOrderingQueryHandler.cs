using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetAll
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<GetAllOrderingQueryResponse>>
    {

        private readonly IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public GetAllOrderingQueryHandler(IOrderingRepository orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrderingQueryResponse>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var allOrderings = await _orderingRepository.GetAllAsync();
            return _mapper.Map<List<GetAllOrderingQueryResponse>>(allOrderings);
        }
    }
}
