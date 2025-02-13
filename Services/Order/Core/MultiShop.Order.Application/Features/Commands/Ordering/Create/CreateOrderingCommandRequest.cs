using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandRequest:IRequest<CreateOrderingCommandResponse>
    {
        public CreateOrderingCommandRequest(string userId, decimal totalPrice, DateTime orderDate)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
        }

        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
