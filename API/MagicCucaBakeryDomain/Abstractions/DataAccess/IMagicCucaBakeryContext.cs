using MagicCucaBakery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Context.Abstractions
{
    public interface IMagicCucaBakeryContext : IDisposable
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OrderProducts> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangesAsync();

        public DbSet<T> GetSet<T>() where T : class;        
    }
}
