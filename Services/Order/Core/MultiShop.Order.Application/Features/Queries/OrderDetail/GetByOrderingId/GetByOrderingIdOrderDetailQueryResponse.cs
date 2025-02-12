namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId
{
    public class GetByOrderingIdOrderDetailQueryResponse
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}