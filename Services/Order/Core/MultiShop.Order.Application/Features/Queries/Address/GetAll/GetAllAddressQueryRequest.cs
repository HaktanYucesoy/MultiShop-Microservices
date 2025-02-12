using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Address.GetAll
{
    public class GetAllAddressQueryRequest:IRequest<List<GetAllAddressQueryResponse>>
    {
    }
}
