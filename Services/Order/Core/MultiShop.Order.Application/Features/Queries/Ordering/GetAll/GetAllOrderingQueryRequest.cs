using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetAll
{
    public class GetAllOrderingQueryRequest:IRequest<List<GetAllOrderingQueryResponse>>
    {
    }
}
