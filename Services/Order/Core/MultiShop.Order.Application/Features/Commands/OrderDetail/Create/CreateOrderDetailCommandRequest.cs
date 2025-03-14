﻿using MediatR;
using MultiShop.Order.Application.Interfaces.Transaction;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandRequest:IRequest<CreateOrderDetailCommandResponse>,ITransactionalCommand
    {
        public string ProductId { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int OrderingId { get; set; }
    }
}
