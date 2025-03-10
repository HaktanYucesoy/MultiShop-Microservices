using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Address.Create;

namespace MultiShop.Order.WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}/addresses")]
    public class AddressController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewAddressAsync(CreateAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
