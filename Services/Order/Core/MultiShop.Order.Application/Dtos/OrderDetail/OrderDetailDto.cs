
namespace MultiShop.Order.Application.Dtos.OrderDetail
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int NewAmount { get; set; }
        public decimal NewPrice { get; set; }
        public string NewName { get; set; }

        public string NewImage { get; set; }
    }
}
