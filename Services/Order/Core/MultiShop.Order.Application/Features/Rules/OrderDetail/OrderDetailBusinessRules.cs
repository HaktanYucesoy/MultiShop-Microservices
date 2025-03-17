using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Application.Rules;

namespace MultiShop.Order.Application.Features.Rules.OrderDetail
{
    public class OrderDetailBusinessRules:BaseBusinessRules
    {
        private readonly IOrderDetailRepository _repository;    
        public OrderDetailBusinessRules(IOrderDetailRepository repository)
        {
            _repository = repository;
          
        }

        public async Task OrderDetailCannotBeDuplicatedWhenInsertedOrUpdatedAsync(int orderId,string productName)
        {
            var existOrderDetail = await _repository.GetByFilterAsync(x => x.OrderingId == orderId && x.ProductName==productName);
            if (existOrderDetail != null)
            {
                throw new BusinessException("Order detail cannot be duplicated.");
            }
        }

       public async Task CannotDeleteOrUpdateToIfNotExistOrderDetailAsync(int orderDetailId)
       {
            var orderDetail = await _repository.GetByIdAsync(orderDetailId);
            if (orderDetail == null)
            {
                throw new NotFoundException("Order detail not found");
            }
       }

       public void CannotDeleteOrUpdateToIfNotExistOrderDetail(Domain.Entities.OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                throw new NotFoundException("Order detail not found");
            }
        }
    }
}
