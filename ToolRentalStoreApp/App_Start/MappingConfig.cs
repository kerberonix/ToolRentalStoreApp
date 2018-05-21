using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolRentalStoreApp.Dtos;
using ToolRentalStoreApp.Models;

namespace ToolRentalStoreApp.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, CustomerDto>();
                config.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>().ForMember(c => c.Id, opt => opt.Ignore());
                config.CreateMap<Order, OrderDto>();
                config.CreateMap<OrderDto, Order>().ForMember(c => c.Id, opt => opt.Ignore());
                config.CreateMap<OrderDetail, OrderProductDetailsDto>();
            });
        }
    }
}