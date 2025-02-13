namespace MultiShop.Order.Application.Features.Queries.Ordering.GetById
{
    public class GetByIdOrderingQueryResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}