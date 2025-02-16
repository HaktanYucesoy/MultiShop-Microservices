using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Address.Create
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {

        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var newAddress= Domain.Entities.Address.Create(request.UserId,
                request.District, 
                request.City,
                request.Detail);

            var response=await _addressRepository.AddAsync(newAddress);

            return _mapper.Map<CreateAddressCommandResponse>(response);
        }
    }
}
