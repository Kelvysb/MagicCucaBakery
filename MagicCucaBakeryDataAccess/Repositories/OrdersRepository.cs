using MagicCucaBakery.Domain.DataAccess.Context.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagicCucaBakery.DataAccess.Repositories
{
    public class OrdersRepository : BaseRepository<Order, OrderDto>, IOrdersRepository
    {
        public OrdersRepository(IMagicCucaBakeryContext context) : base(context)
        {
        }

        public override Task<List<OrderDto>> GetAll()
        {
            return context.Orders
                .Select(OrderProjection())
                .ToListAsync();
        }
        
        public override Task<OrderDto> GetById(int id)
        {
            return context.Orders
                .Where(o => o.Id == id)
                .Select(OrderProjection())
                .FirstOrDefaultAsync();
        }

        public override Task<int> Add(Order entity)
        {
            context.Orders.Add(entity);
            return context.SaveChangesAsync();
        }

        public override Task<int> Delete(int id)
        {
            context.Orders.Remove(new Order() { Id = id });
            return context.SaveChangesAsync();
        }        

        public override Task<int> Update(Order entity)
        {
            context.Orders.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task<int> AddItem(OrderProducts item)
        {
            context.OrderProducts.Add(item);
            return context.SaveChangesAsync();
        }

        public Task<int> UpdateItem(OrderProducts item)
        {
            context.OrderProducts.Update(item);
            return context.SaveChangesAsync();
        }

        public Task<int> RemoveItem(int itemId)
        {
            context.OrderProducts.Remove(new OrderProducts() { Id = itemId });
            return context.SaveChangesAsync();
        }

        private static Expression<Func<Order, OrderDto>> OrderProjection()
        {
            return o => new OrderDto()
            {
                Id = o.Id,
                Status = o.Status,
                DeliveryDate = o.DeliveryDate,
                CreationDate = o.CreationDate,
                Observation = o.Observation,
                Customer = new CustomerDto()
                {
                    Id = o.Customer.Id,
                    FirstName = o.Customer.FirstName,
                    LastName = o.Customer.LastName,
                    Email = o.Customer.Email,
                    PhoneNumber = o.Customer.PhoneNumber,
                    Active = o.Customer.Active,
                    Address = new CustomerAddressDto()
                    {
                        City = o.Customer.Address.City,
                        Complement = o.Customer.Address.Complement,
                        Neighborhood = o.Customer.Address.Neighborhood,
                        Number = o.Customer.Address.Number,
                        PostalCode = o.Customer.Address.PostalCode,
                        State = o.Customer.Address.State,
                        Street = o.Customer.Address.Street
                    }
                },
                Items = o.OrderProducts.Select(i => new OrderItemDto()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Description = i.Product.Description,
                    Price = i.Product.Price,
                    Status = i.Status,
                    Quantity = i.Quantity,
                    Weight = i.Product.Weight,
                    Observation = i.Observation
                }).ToList(),
                ItemQuantity = o.OrderProducts.Sum(o => o.Quantity),
                ItemsTotalWeight = o.OrderProducts.Sum(p => p.Quantity * p.Product.Weight),
                TotalValue = o.OrderProducts.Sum(p => p.Quantity * p.Product.Price)
            };
        }       
    }
}
