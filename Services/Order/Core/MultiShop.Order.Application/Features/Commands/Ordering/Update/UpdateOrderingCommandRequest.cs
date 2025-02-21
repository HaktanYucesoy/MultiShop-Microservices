using MediatR;
using MultiShop.Order.Application.Interfaces.Transaction;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandRequest : IRequest<UpdateOrderingCommandResponse>,ITransactionalCommand
    {
        public int Id { get; set; }
        public Domain.Entities.Address? DeliveryAddress { get; set; }
        public List<Domain.Entities.OrderDetail>? OrderDetails { get; set; }
    }
}
