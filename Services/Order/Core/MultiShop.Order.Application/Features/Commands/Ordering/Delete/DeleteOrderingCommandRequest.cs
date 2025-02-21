using MediatR;
using MultiShop.Order.Application.Interfaces.Transaction;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Delete
{
    public class DeleteOrderingCommandRequest:IRequest<DeleteOrderingCommandResponse>,ITransactionalCommand
    {
        public int Id { get; set; }
        public DeleteOrderingCommandRequest(int id)
        {
            Id = id;
        }
    }
}