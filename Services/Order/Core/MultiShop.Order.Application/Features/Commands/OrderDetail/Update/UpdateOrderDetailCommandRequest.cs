﻿using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandRequest : IRequest<UpdateOrderDetailCommandResponse>
    {
        public UpdateOrderDetailCommandRequest(int id, string productId, int productAmount, decimal productPrice, string productName, string productImage, decimal productTotalPrice, int orderingId)
        {
            Id = id;
            ProductId = productId;
            ProductAmount = productAmount;
            ProductPrice = productPrice;
            ProductName = productName;
            ProductImage = productImage;
            ProductTotalPrice = productTotalPrice;
            OrderingId = orderingId;
        }
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
