using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {

            var existingAddress = await _addressRepository.GetByIdAsync(request.Id);
            if (existingAddress == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Address), request.Id);
            }

            var updatedAddress = Domain.Entities.Address.Create(request.UserId,request.District,request.City,request.Detail);
            updatedAddress.Id = request.Id;

            var response = await _addressRepository.UpdateAsync(updatedAddress);    
            return _mapper.Map<UpdateAddressCommandResponse>(response);
        }
    }
}
