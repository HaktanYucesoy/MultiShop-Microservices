
using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetById
{
    public class GetByIdOrderDetailQueryRequest:IRequest<GetByIdOrderDetailQueryResponse>
    {
        public GetByIdOrderDetailQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
