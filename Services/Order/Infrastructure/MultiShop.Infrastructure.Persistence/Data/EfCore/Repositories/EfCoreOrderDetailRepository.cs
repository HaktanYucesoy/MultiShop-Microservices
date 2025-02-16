using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Repositories
{
    public class EfCoreOrderDetailRepository : BaseEfCoreRepository<OrderDetail>,
        IOrderDetailRepository

    {
        public EfCoreOrderDetailRepository(OrderContext orderContext) : base(orderContext)
        {
        }
    }
}
