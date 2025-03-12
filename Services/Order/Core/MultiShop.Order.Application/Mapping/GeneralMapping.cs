using AutoMapper;
using MultiShop.Order.Application.Features.Commands.Address.Create;
using MultiShop.Order.Application.Features.Commands.Address.Update;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Create;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Update;
using MultiShop.Order.Application.Features.Commands.Ordering.Create;
using MultiShop.Order.Application.Features.Commands.Ordering.Update;
using MultiShop.Order.Application.Features.Queries.Address.GetAll;
using MultiShop.Order.Application.Features.Queries.Address.GetById;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetById;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetByOrderingId;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetByProductId;
using MultiShop.Order.Application.Features.Queries.Ordering.GetAll;
using MultiShop.Order.Application.Features.Queries.Ordering.GetById;
using MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Address, GetAllAddressQueryResponse>()
             .ReverseMap();
            CreateMap<Address,GetByIdAddressQueryResponse>()
                .ReverseMap();
            CreateMap<Address, GetByUserIdOrderingQueryResponse>()
                .ReverseMap();
            CreateMap<Address, CreateAddressCommandResponse>()
                .ReverseMap();
            CreateMap<Address, UpdateAddressCommandResponse>()
                .ReverseMap();



            CreateMap<OrderDetail, GetAllOrderDetailQueryResponse>()
                .ReverseMap();
            CreateMap<OrderDetail, GetByIdOrderDetailQueryResponse>()
                .ReverseMap();
            CreateMap<OrderDetail, GetByUserIdOrderingQueryResponse>()
                .ReverseMap();
            CreateMap<OrderDetail, GetByProductIdOrderDetailQueryResponse>()
                .ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommandResponse>()
                .ReverseMap();
            CreateMap<OrderDetail,UpdateOrderDetailCommandResponse>()
                .ReverseMap();
            CreateMap<OrderDetail, GetByOrderingIdOrderDetailQueryResponse>()
            .ReverseMap();


            CreateMap<Ordering, GetAllOrderingQueryResponse>()
                .ReverseMap();
            CreateMap<Ordering, GetByUserIdOrderingQueryResponse>()
                .ReverseMap();
            CreateMap<Ordering, GetByIdOrderingQueryResponse>()
                .ReverseMap();
            CreateMap<Ordering, CreateOrderingCommandResponse>()
                .ReverseMap();
            CreateMap<Ordering, UpdateOrderingCommandResponse>()
                .ReverseMap();

        }
    }
}
