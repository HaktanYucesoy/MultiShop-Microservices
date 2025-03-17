using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Application.Rules;

namespace MultiShop.Order.Application.Features.Rules.Ordering
{
    public class OrderingBusinessRules:BaseBusinessRules
    {
        private readonly IOrderingRepository _orderingRepository;

        public OrderingBusinessRules(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task WhenDeleteToAddressIfRelatedOrderingAsync(int addressId)
        {

            var order = await _orderingRepository.GetByFilterAsync(x => x.DeliveryAddressId == addressId);

            if (order != null)
            {
                throw new BusinessException("You must delete your order before deleting address.");
            }

        }
        public void CannotDeleteOrUpdateToIfNotExistOrdering(Domain.Entities.Ordering ordering)
        {
            if (ordering == null)
            {
                throw new NotFoundException("Ordering not found");
            }
        }



        
    }
}
