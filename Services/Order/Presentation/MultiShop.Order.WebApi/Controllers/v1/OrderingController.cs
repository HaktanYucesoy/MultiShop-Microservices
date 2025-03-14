﻿using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Ordering.Create;
using MultiShop.Order.Application.Features.Queries.Ordering.GetAll;

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

        [HttpGet]
        public async Task<IActionResult> GetOrderingsAsync()
        {
            var result = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(result);
        }
    } 
}
