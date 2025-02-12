

using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Create
{
    public class CreateAddressCommandRequest:IRequest<CreateAddressCommandResponse>
    {
        public CreateAddressCommandRequest(string userId, string district, string city, string detail)
        {
            UserId = userId;
            District = district;
            City = city;
            Detail = detail;
        }

        public string UserId { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Detail { get; set; }
    }
}
