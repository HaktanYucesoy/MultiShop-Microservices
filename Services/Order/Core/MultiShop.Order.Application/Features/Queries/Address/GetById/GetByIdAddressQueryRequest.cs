
using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Address.GetById
{
    public class GetByIdAddressQueryRequest:IRequest<GetByIdAddressQueryResponse>
    {
        public GetByIdAddressQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
