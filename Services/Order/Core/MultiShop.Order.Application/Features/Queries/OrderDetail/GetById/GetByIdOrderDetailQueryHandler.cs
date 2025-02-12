using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetById
{
    public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQueryRequest, GetByIdOrderDetailQueryResponse>
    {
        public Task<GetByIdOrderDetailQueryResponse> Handle(GetByIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
