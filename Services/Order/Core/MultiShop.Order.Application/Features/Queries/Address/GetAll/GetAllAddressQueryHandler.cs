using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Queries.Address.GetAll
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, List<GetAllAddressQueryResponse>>
    {
        private readonly IAddressRepository _addressRepository;
        private IMapper _mapper;

        public GetAllAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAddressQueryResponse>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var allAddress = await _addressRepository.GetAllAsync();
            return _mapper.Map<List<GetAllAddressQueryResponse>>(allAddress);
        }
    }
}
