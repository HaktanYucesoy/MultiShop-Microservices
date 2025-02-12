using MultiShop.Order.Domain.Common;

namespace MultiShop.Order.Domain.Entities
{
    public class Ordering:BaseEntity<int>
    {
        public string UserId { get; set; }     
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


    }
}