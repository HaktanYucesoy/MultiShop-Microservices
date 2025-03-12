using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Interfaces.Repositories
{
    public interface IOrderingRepository:IRepository<Ordering,int>
    {
        Task<Ordering> UpdateOrderWithAddedToNewOrderDetail(Ordering ordering, OrderDetail orderDetail);

        Task<Ordering> UpdateOrderWithUpdatedToNewOrderDetailsAndAddress(Ordering ordering, List<OrderDetail> orderDetails, Address deliveryAddress);


        Task<Ordering> UpdateOrderWithUpdatedToOrderDetail(Ordering ordering,
            OrderDetail orderDetail);
        Task<Ordering> GetOrderingWithOrderDetails(int id);

        Task<Ordering> GetOrderingWithOrderDetailsAndAddress(int id);

        Task<bool> DeleteOrderWithDetails(int id);
    }
}
