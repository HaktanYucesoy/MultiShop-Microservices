using MediatR;
using MultiShop.Order.Application.Interfaces.Transaction;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandRequest:IRequest<CreateOrderingCommandResponse>,ITransactionalCommand
    {
        public CreateOrderingCommandRequest(string userId,int deliveryAddressId)
        {
            UserId = userId;
            DeliveryAddressId = deliveryAddressId;
        }

        public string UserId { get; set; }
        public int DeliveryAddressId { get; set; }
    }
}
