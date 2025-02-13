using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Delete
{
    public class DeleteOrderingCommandRequest:IRequest<DeleteOrderingCommandResponse>
    {
        public int Id { get; set; }
        public DeleteOrderingCommandRequest(int id)
        {
            Id = id;
        }
    }
}