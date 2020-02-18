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
    public class CustomersRepository : BaseRepository<Customer, CustomerDto>, ICustomersRepository
    {
        public CustomersRepository(IMagicCucaBakeryContext context) : base(context)
        {
        }

        public override Task<List<CustomerDto>> GetAll()
        {
            return context.Customers
                .Select(CustomerProjection())
                .AsNoTracking()
                .ToListAsync();
        }        

        public override Task<CustomerDto> GetById(int id)
        {
            return context.Customers
                .Where(c => c.Id == id)
                .Select(CustomerProjection())
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<List<CustomerDto>> GetByName(string name)
        {
            return context.Customers
                .Where(c => c.FirstName.Contains(name))
                .Select(CustomerProjection())
                .AsNoTracking()
                .ToListAsync();
        }

        public override Task<int> Add(Customer entity)
        {
            context.Customers.Add(entity);
            return context.SaveChangesAsync();
        }

        public override Task<int> Delete(int id)
        {
            context.Customers.Remove(new Customer() { Id = id});
            return context.SaveChangesAsync();
        }

        public override Task<int> Update(Customer entity)
        {
            context.Customers.Update(entity);
            return context.SaveChangesAsync();
        }

        private Expression<Func<Customer, CustomerDto>> CustomerProjection()
        {
            return c => new CustomerDto()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Active = c.Active,
                Address = new CustomerAddressDto()
                {
                    City = c.Address.City,
                    Complement = c.Address.Complement,
                    Neighborhood = c.Address.Neighborhood,
                    Number = c.Address.Number,
                    PostalCode = c.Address.PostalCode,
                    State = c.Address.State,
                    Street = c.Address.Street
                }
            };
        }
    }
}
