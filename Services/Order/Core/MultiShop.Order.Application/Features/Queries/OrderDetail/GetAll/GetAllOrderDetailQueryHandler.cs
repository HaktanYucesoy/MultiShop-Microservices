using MediatR;


namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, GetAllOrderDetailQueryResponse>
    {
        public Task<GetAllOrderDetailQueryResponse> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
