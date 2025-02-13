namespace MultiShop.Order.Application.Features.Queries.Ordering.GetAll
{
    public class GetAllOrderingQueryResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}