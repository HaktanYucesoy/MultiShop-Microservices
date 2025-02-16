using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;

namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Repositories
{
    public class EfCoreOrderingRepository : BaseEfCoreRepository<Ordering>, IOrderingRepository
    {
        public EfCoreOrderingRepository(OrderContext orderContext) : base(orderContext)
        {

        }

        public async Task<Ordering> GetOrderingWithOrderDetails(int id)
        {
            var response=await _orderContext.Orderings
           .Include(o => o.OrderDetails)
           .FirstOrDefaultAsync(o => o.Id == id);

            if (response == null)
                return null!;

            return response;
        }

        public async Task<Ordering> GetOrderingWithOrderDetailsAndAddress(int id)
        {
            var response = await _orderContext.Orderings
          .Include(o => o.OrderDetails)
          .Include(o => o.DeliveryAddress)
          .FirstOrDefaultAsync(o => o.Id == id);

            if (response == null)
                return null!;

            return response;
        }

        public async Task<Ordering> UpdateOrderWithAddedToNewOrderDetail(Ordering ordering, OrderDetail orderDetail)
        {
            var existingOrdering =await GetOrderingWithOrderDetails(ordering.Id);

            _orderContext.OrderDetails.Add(orderDetail);
            _orderContext.Entry(existingOrdering).CurrentValues.SetValues(ordering);
            await _orderContext.SaveChangesAsync();

            return await GetOrderingWithOrderDetails(ordering.Id);

        }

        public Task<Ordering> UpdateOrderWithUpdatedToNewOrderDetailsAndAddress(Ordering ordering, List<OrderDetail> orderDetails, Address deliveryAddress)
        {
            throw new NotImplementedException();
        }
    }
}
