using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Ordering.Create;
using MultiShop.Order.Application.Features.Commands.Ordering.Delete;
using MultiShop.Order.Application.Features.Commands.Ordering.Update;
using MultiShop.Order.Application.Features.Queries.Ordering.GetAll;
using MultiShop.Order.Application.Features.Queries.Ordering.GetById;

namespace MultiShop.Order.WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}/orderings")]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewOrderingAsync(CreateOrderingCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrderingAsync(UpdateOrderingCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderingAsync(int id)
        {
            var request = new DeleteOrderingCommandRequest(id);
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderingsAsync()
        {
            var result = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdOrderingQueryRequest(id));
            return Ok(result);
        }
    } 
}
