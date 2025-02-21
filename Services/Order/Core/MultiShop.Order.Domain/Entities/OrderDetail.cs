using MultiShop.Order.Application.Exceptions.OrderDetail;
using MultiShop.Order.Domain.Common;
namespace MultiShop.Order.Domain.Entities
{
    public class OrderDetail:BaseEntity<int>
    {

        private OrderDetail(){}

        public static OrderDetail Create(string productId, int productAmount, decimal productPrice, string productName, string productImage)
        {
            if (productAmount <= 0)
                throw new OrderDetailDomainRuleException("Amount must be greater than zero");

            var newOrderDetail=new OrderDetail
            {
                ProductId = productId,
                ProductAmount = productAmount,
                ProductPrice = productPrice,
                ProductName = productName,
                ProductImage = productImage
            };

            newOrderDetail.CalculateTotalPrice();
            return newOrderDetail;

        }

        public void SetOrderingRelation(Ordering ordering)
        {
            OrderingId = ordering.Id;
            Ordering = ordering;
        }

        public void UpdateDetails(int newAmount, decimal newPrice,string newName,string newImage,int orderingId)
        {
            if (newAmount <= 0)
                throw new OrderDetailDomainRuleException("Amount must be greater than zero");
            if (newPrice <= 0)
                throw new OrderDetailDomainRuleException("Price must be greater than zero");
            if(String.IsNullOrEmpty(newName))
                throw new OrderDetailDomainRuleException("Name cannot be empty");
            if (String.IsNullOrEmpty(newImage))
                throw new OrderDetailDomainRuleException("Image cannot be empty");

            ProductAmount = newAmount;
            ProductPrice = newPrice;
            ProductImage = newImage;
            ProductName = newName;
            OrderingId = orderingId;
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            ProductTotalPrice = ProductPrice * ProductAmount;
        }

        public string ProductId { get; set; }
        public int  ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }   
}
