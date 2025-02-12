using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Address.GetAll
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, List<GetAllAddressQueryResponse>>
    {
        public Task<List<GetAllAddressQueryResponse>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
