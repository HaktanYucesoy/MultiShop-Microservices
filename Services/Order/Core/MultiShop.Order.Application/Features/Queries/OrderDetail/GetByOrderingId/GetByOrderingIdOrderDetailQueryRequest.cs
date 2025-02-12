using MediatR;
namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId
{
    public class GetByOrderingIdOrderDetailQueryRequest : IRequest<GetByOrderingIdOrderDetailQueryResponse>
    {

        public int OrderingId { get; set; }

        public GetByOrderingIdOrderDetailQueryRequest(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}
