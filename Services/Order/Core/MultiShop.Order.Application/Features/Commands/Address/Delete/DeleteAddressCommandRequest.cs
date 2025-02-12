using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Delete
{
    public class DeleteAddressCommandRequest: IRequest<DeleteAddressCommandResponse>
    {
        public DeleteAddressCommandRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
