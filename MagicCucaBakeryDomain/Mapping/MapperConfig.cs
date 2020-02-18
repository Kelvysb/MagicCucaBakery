using AutoMapper;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Linq;

namespace MagicCucaBakery.Domain.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            ConfigureCustomers();
            ConfigureProducts();
            ConfigureOrders();
            ConfigureOrderProducts();
            ConfigureAddress();
            ConfigureUser();
        }

        private void ConfigureCustomers()
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
        }

        private void ConfigureProducts()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }

        private void ConfigureOrders()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.OrderProducts
                           .Select(op => new OrderItemDto
                           {
                               Name = op.Product.Name,
                               Description = op.Product.Description,
                               Price = op.Product.Price,
                               Weight = op.Product.Weight,
                               Quantity = op.Quantity,
                               ProductId = op.ProductId,
                               Status = op.Status
                           })));

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderProducts,
                           opt => opt.MapFrom(src => src.Items
                           .Select(op => new OrderProducts
                           {
                               Quantity = op.Quantity,
                               ProductId = op.ProductId,
                               Status = op.Status,
                               Observation = op.Observation
                           })))
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(o => o.Customer.Id));

        }
        private void ConfigureAddress()
        {
            CreateMap<CustomerAddressDto, CustomerAddress>()
                .ReverseMap();
        }

        private void ConfigureOrderProducts()
        {
            CreateMap<OrderProducts, OrderItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.Observation))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Product.Weight))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description));

            CreateMap<OrderItemDto, OrderProducts>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.Observation))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore());
        }

        private void ConfigureUser()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
