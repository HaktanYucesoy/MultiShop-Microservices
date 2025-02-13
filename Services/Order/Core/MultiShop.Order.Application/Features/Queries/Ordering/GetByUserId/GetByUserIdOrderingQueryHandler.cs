using MediatR;


namespace MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId
{
    public class GetByUserIdOrderingQueryHandler : IRequestHandler<GetByUserIdOrderingQueryRequest, GetByUserIdOrderingQueryResponse>
    {
        public Task<GetByUserIdOrderingQueryResponse> Handle(GetByUserIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
