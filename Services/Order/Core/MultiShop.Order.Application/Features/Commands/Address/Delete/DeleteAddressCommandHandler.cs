using MediatR;
using MultiShop.Order.Application.Features.Rules.Ordering;
using MultiShop.Order.Application.Interfaces.Repositories;

namespace MultiShop.Order.Application.Features.Commands.Address.Delete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {

        private readonly IAddressRepository _addressRepository;
        private readonly OrderingBusinessRules _orderingBusinessRules;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository, OrderingBusinessRules orderingBusinessRules)
        {
            _addressRepository = addressRepository;
            _orderingBusinessRules = orderingBusinessRules;
        }
        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderingBusinessRules.WhenDeleteToAddressIfRelatedOrderingAsync(request.Id);

            var response = await _addressRepository.DeleteAsync(request.Id);

            return new DeleteAddressCommandResponse()
            {
                IsSuccess = response
            };
        }
    }
}
