using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryRequest:IRequest<List<GetAllOrderDetailQueryResponse>>
    {
    }
}
