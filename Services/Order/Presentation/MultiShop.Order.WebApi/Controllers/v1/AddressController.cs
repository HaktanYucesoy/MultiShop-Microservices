using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Address.Create;
using MultiShop.Order.Application.Features.Commands.Address.Delete;
using MultiShop.Order.Application.Features.Commands.Address.Update;
using MultiShop.Order.Application.Features.Queries.Address.GetAll;
using MultiShop.Order.Application.Features.Queries.Address.GetById;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAddressAsync(int id)
        {
            var result = await _mediator.Send(new GetByIdAddressQueryRequest(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddressesAsync()
        {
            var result = await _mediator.Send(new GetAllAddressQueryRequest());
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync(UpdateAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            var request = new DeleteAddressCommandRequest(id);
            var result = await _mediator.Send(request);
            return Ok(result);
        }


    }
}
