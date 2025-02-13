using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId
{
    public class GetByUserIdOrderingQueryRequest:IRequest<GetByUserIdOrderingQueryResponse>
    {
        public string UserId { get; set; }


        public GetByUserIdOrderingQueryRequest(string userId)
        {
            UserId = userId;
        }
    }
}
