using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Application.Interfaces.Rules;


namespace MultiShop.Order.Application.Features.Rules.Address
{
    public class AddressBusinessRules:IBaseBusinessRules
    {
        private readonly IAddressRepository _repository;
        private readonly IOrderingRepository _orderingRepository;
        public AddressBusinessRules(IAddressRepository repository, IOrderingRepository orderingRepository)
        {
            _repository = repository;
            _orderingRepository = orderingRepository;
        }

        public async Task WhenDeleteToAddressIfRelatedOrdering(int addressId)
        {
         
            var order = await _orderingRepository.GetByFilterAsync(x=>x.DeliveryAddressId==addressId);

            if (order != null)
            {
                throw new BusinessException("You must delete your order before deleting address.");
            }

        }

        public async Task AddressDetailCannotBeDuplicatedWhenInsertedOrUpdated(string detail,string userId)
        {
            var existAddress=await _repository.GetByFilterAsync(x=>x.Detail==detail && x.UserId== userId);

            if (existAddress != null)
            {
                throw new BusinessException("Address detail cannot be duplicated.");
            }
        }

        public async Task CannotUpdatedOrDeletedToNotExistsAddress(int addressId)
        {
            var address = await _repository.GetByIdAsync(addressId);
            if (address == null)
            {
                throw new NotFoundException("Address not found");
            }
        }


    }
}
