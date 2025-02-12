using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByProductId
{
    public class GetByProductIdOrderDetailQueryRequest:IRequest<GetByProductIdOrderDetailQueryResponse>
    {
        public GetByProductIdOrderDetailQueryRequest(string productId)
        {
            ProductId = productId;
        }

        public string ProductId { get; set; }


    }
}
