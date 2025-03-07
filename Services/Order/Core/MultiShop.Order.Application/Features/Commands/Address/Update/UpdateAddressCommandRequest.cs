

using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandRequest:IRequest<UpdateAddressCommandResponse>
    {
        public int Id { get; set; }     
        public string City { get; set; }
        public string District { get; set; }
        public string UserId { get; set; }
        public string Detail { get; set; }
    }
}
