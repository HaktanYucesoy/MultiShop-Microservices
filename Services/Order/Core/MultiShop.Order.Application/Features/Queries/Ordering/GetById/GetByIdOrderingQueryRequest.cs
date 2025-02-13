
using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetById
{
    public class GetByIdOrderingQueryRequest:IRequest<GetByIdOrderingQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdOrderingQueryRequest(int id)
        {
            Id = id;
        }
    }
}
