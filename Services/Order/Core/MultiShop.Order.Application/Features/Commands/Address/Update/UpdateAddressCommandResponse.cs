namespace MultiShop.Order.Application.Features.Commands.Address.Update
{
    public class UpdateAddressCommandResponse
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}