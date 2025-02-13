using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandRequest:IRequest<DeleteOrderDetailCommandResponse>
    {
        public DeleteOrderDetailCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
