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

        public async Task<bool> DeleteOrderWithDetails(int id)
        {
            var defaultOrder=await _orderContext.Orderings
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (defaultOrder == null)
                return false;

            _orderContext.OrderDetails.RemoveRange(defaultOrder.OrderDetails);
            _orderContext.Orderings.Remove(defaultOrder);

            return await _orderContext.SaveChangesAsync() > 0;
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

        public async Task<Ordering> UpdateOrderWithUpdatedToNewOrderDetailsAndAddress(Ordering ordering, List<OrderDetail> orderDetails, Address deliveryAddress)
        {
            var existingOrdering = await GetOrderingWithOrderDetailsAndAddress(ordering.Id);

            if (existingOrdering == null)
                return null!;

            if (deliveryAddress != null && ordering.DeliveryAddress != null)
            {
                _orderContext.Entry(existingOrdering.DeliveryAddress)
                        .CurrentValues.SetValues(deliveryAddress);
            }

            if (orderDetails?.Any() == true)
            {
                foreach (var updatedDetail in orderDetails)
                {
                    var existingDetail = existingOrdering.OrderDetails
                        .FirstOrDefault(d => d.Id == updatedDetail.Id);

                    if (existingDetail != null)
                    {
                        _orderContext.Entry(existingDetail)
                            .CurrentValues.SetValues(updatedDetail);
                    }
                }
            }


            _orderContext.Entry(existingOrdering)
                .CurrentValues.SetValues(ordering);

            await _orderContext.SaveChangesAsync();

            return await GetOrderingWithOrderDetailsAndAddress(ordering.Id);
        }

        public async Task<Ordering> UpdateOrderWithUpdatedToOrderDetail(Ordering ordering, OrderDetail orderDetail)
        {

            var existOrder = await GetOrderingWithOrderDetails(ordering.Id);

            if (existOrder == null)
                return null!;

            var existingDetail = existOrder.OrderDetails.FirstOrDefault(x=>x.Id == orderDetail.Id);

            if(existingDetail == null)
                return null!;

            _orderContext.Entry(existingDetail).CurrentValues.SetValues(orderDetail);
            _orderContext.Entry(existOrder).CurrentValues.SetValues(ordering);

            await _orderContext.SaveChangesAsync();

            return await GetOrderingWithOrderDetailsAndAddress(ordering.Id);

        }
    }
}
