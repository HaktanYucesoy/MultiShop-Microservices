using MultiShop.Order.Domain.Common;
using MultiShop.Order.Domain.Exceptions.Address;
using MultiShop.Order.Domain.Exceptions.OrderDetail;

namespace MultiShop.Order.Domain.Entities
{
    public class Ordering : BaseEntity<int>
    {
        private readonly List<OrderDetail> _orderDetails;

        private Ordering()
        {
            _orderDetails = new List<OrderDetail>();
            OrderDate = DateTime.Now;
        }


        public string UserId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime OrderDate { get; private set; }

        public int DeliveryAddressId { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();

        public static Ordering Create(string userId, Address deliveryAddress)
        {

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId cannot be empty");

            var ordering = new Ordering
            {
                UserId = userId,
                DeliveryAddress = deliveryAddress
            };
            return ordering;

        }

        public void AddOrderDetail(string productId, int productAmount, decimal productPrice, string productName, string productImage)
        {
            var orderDetail = OrderDetail.Create(productId, productAmount, productPrice, productName, productImage);

            orderDetail.SetOrderingRelation(this);
            _orderDetails.Add(orderDetail);
            RecalculateTotalPrice();
        }

        public void UpdateDeliveryAddress(string district, string city, string detail)
        {
            if (string.IsNullOrEmpty(district) || string.IsNullOrEmpty(city))
                throw new AddressDomainRuleException("District and City cannot be empty");

            DeliveryAddress = Address.Create(this.UserId, district, city, detail);
        }

        public void UpdateOrderDetail(int orderDetailId, int newAmount, decimal newPrice,string newProductName,string newProductImage)
        {
            var orderDetail = _orderDetails.FirstOrDefault(od => od.Id == orderDetailId);
            if (orderDetail == null)
                throw new OrderDetailDomainNotFoundException(orderDetailId);

            orderDetail.UpdateDetails(newAmount, newPrice,newProductName,newProductImage);
            orderDetail.Id = orderDetailId;
            RecalculateTotalPrice();
        }

        private void RecalculateTotalPrice()
        {
            TotalPrice = _orderDetails.Sum(od => od.ProductTotalPrice);
        }
    }
}