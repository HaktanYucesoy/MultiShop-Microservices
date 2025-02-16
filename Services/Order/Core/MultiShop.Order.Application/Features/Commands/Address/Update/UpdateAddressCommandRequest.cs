

using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandRequest:IRequest<UpdateAddressCommandResponse>
    {
        public UpdateAddressCommandRequest(int id, string city, string district, string userId)
        {
            Id = id;
            City = city;
            District = district;
            UserId = userId;
        }

        public int Id { get; set; }     
        public string City { get; set; }
        public string District { get; set; }
        public string UserId { get; set; }
        public string Detail { get; internal set; }
    }
}
