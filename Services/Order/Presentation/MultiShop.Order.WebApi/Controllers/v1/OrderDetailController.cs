using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Create;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Delete;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Update;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetById;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId;

namespace MultiShop.Order.WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}/orderDetails")]
    public class OrderDetailController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddOrderDetailAsync(CreateOrderDetailCommandRequest request)
        {

            var response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetailAsync(UpdateOrderDetailCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetailAsync(int id)
        {
            var request=new DeleteOrderDetailCommandRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("detailList/{orderingId}")]
        public async Task<IActionResult> GetOrderDetailsOrderingId(int orderingId)
        {
            var request = new GetByOrderingIdOrderDetailQueryRequest(orderingId);

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var request = new GetByIdOrderDetailQueryRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }

}
