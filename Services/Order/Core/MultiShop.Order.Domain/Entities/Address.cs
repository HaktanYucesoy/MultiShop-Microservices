using MultiShop.Order.Domain.Common;

namespace MultiShop.Order.Domain.Entities
{
    public class Address:BaseEntity<int>
    {
        public string UserId { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Detail { get; set; }
    }
}
