using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest, CreateOrderingCommandResponse>
    {
        private readonly IOrderingRepository _orderingRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateOrderingCommandHandler(IOrderingRepository orderingRepository,
            IMapper mapper,
            IAddressRepository addressRepository)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<CreateOrderingCommandResponse> Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            
            var address = await _addressRepository.GetByIdAsync(request.DeliveryAddressId);
            if (address == null)
                throw new NotFoundException(nameof(Address), request.DeliveryAddressId);

            var newOrdering = Domain.Entities.Ordering.Create(request.UserId,address);
            var createOrderingResponse = await _orderingRepository.AddAsync(newOrdering);

            return _mapper.Map<CreateOrderingCommandResponse>(createOrderingResponse);
        }
    }
}
