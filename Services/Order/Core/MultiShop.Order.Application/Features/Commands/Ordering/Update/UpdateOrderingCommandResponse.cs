namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandResponse
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int DeliveryAddressId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; private set; }
    }
}