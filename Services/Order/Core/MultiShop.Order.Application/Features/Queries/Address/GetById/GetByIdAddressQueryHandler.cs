using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Queries.Address.GetById
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, GetByIdAddressQueryResponse>
    {

        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetByIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAddressQueryResponse> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            
            var address=await _addressRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdAddressQueryResponse>(address);
        }
    }
}
