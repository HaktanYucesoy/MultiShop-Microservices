using MediatR;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetByProductId
{
    public class GetByProductIdOrderDetailQueryHandler : IRequestHandler<GetByProductIdOrderDetailQueryRequest, GetByProductIdOrderDetailQueryResponse>
    {
        public Task<GetByProductIdOrderDetailQueryResponse> Handle(GetByProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
