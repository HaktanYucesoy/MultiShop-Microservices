using MediatR;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId
{
    public class GetByOrderingIdOrderDetailHandler : IRequestHandler<GetByOrderingIdOrderDetailQueryRequest, GetByOrderingIdOrderDetailQueryResponse>
    {
        public Task<GetByOrderingIdOrderDetailQueryResponse> Handle(GetByOrderingIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
