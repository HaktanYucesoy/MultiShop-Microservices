using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetById
{
    public class GetByIdOrderingQueryHandler : IRequestHandler<GetByIdOrderingQueryRequest, GetByIdOrderingQueryResponse>
    {

        private readonly IOrderingRepository _orderingRepository;
        private IMapper _mapper;

        public GetByIdOrderingQueryHandler(IOrderingRepository orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdOrderingQueryResponse> Handle(GetByIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var ordering=await _orderingRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdOrderingQueryResponse>(ordering);
        }
    }
}
