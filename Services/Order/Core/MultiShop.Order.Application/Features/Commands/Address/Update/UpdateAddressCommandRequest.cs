

using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandRequest:IRequest<UpdateAddressCommandResponse>
    {
        public UpdateAddressCommandRequest(int id, string address, string city, string postalCode, string country)
        {
            Id = id;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
