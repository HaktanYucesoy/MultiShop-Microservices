using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Application.Interfaces.Rules;


namespace MultiShop.Order.Application.Features.Rules.Address
{
    public class AddressBusinessRules:IBaseBusinessRules
    {
        private readonly IAddressRepository _repository;
        
        public AddressBusinessRules(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task AddressDetailCannotBeDuplicatedWhenInsertedOrUpdatedAsync(string detail,string userId)
        {
            var existAddress=await _repository.GetByFilterAsync(x=>x.Detail==detail && x.UserId== userId);

            if (existAddress != null)
            {
                throw new BusinessException("Address detail cannot be duplicated.");
            }
        }

        public async Task CannotUpdatedOrDeletedToNotExistsAddressAsync(int addressId)
        {
            var address = await _repository.GetByIdAsync(addressId);
            if (address == null)
            {
                throw new NotFoundException("Address not found");
            }
        }

        public void CannotUpdatedOrDeletedToNotExistsAddress(Domain.Entities.Address? address)
        {
            if (address == null)
            {
                throw new NotFoundException("Address not found");
            }
        }


    }
}
