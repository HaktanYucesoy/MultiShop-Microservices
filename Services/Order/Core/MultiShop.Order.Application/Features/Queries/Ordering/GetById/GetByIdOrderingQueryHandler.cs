using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetById
{
    public class GetByIdOrderingQueryHandler : IRequestHandler<GetByIdOrderingQueryRequest, GetByIdOrderingQueryResponse>
    {
        public Task<GetByIdOrderingQueryResponse> Handle(GetByIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
