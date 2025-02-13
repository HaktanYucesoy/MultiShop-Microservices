using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetAll
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, GetAllOrderingQueryResponse>
    {
        public Task<GetAllOrderingQueryResponse> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
