using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Address.GetById
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, GetByIdAddressQueryResponse>
    {
        public Task<GetByIdAddressQueryResponse> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
