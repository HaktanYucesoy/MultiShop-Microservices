using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;


namespace MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId
{
    public class GetByUserIdOrderingQueryHandler : IRequestHandler<GetByUserIdOrderingQueryRequest, GetByUserIdOrderingQueryResponse>
    {
        private readonly IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public GetByUserIdOrderingQueryHandler(IOrderingRepository orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }
        public async Task<GetByUserIdOrderingQueryResponse> Handle(GetByUserIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var ordering = await _orderingRepository.GetByFilterAsync(x => x.UserId == request.UserId);
            return _mapper.Map<GetByUserIdOrderingQueryResponse>(ordering);
        }
    }
}
