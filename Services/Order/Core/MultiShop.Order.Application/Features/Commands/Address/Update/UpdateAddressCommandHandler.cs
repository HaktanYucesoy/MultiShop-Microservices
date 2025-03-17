using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Features.Rules.Address;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private AddressBusinessRules _addressBusinessRules;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, AddressBusinessRules addressBusinessRules)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _addressBusinessRules = addressBusinessRules;
        }
        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {

            var existingAddress = await _addressRepository.GetByIdAsync(request.Id);
            _addressBusinessRules.CannotUpdatedOrDeletedToNotExistsAddress(existingAddress);

            var updatedAddress = Domain.Entities.Address.Create(request.UserId,request.District,request.City,request.Detail);
            updatedAddress.Id = request.Id;

            var response = await _addressRepository.UpdateAsync(updatedAddress);    
            return _mapper.Map<UpdateAddressCommandResponse>(response);
        }
    }
}
