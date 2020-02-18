using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MagicCucaBakery.Domain.Entities;
using MagicCucaBakery.Domain.DataAccess.Context.Abstractions;
using MagicCucaBakery.Domain.Helpers;

namespace MagicCucaBakery.DataAccess.Context
{
    public class MagicCucaBakeryContext : DbContext, IMagicCucaBakeryContext
    {
        private readonly IConfiguration config;

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OrderProducts> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public MagicCucaBakeryContext(DbContextOptions<MagicCucaBakeryContext> options, IConfiguration config) : base(options)
        {          
            this.config = config;
        }

        public MagicCucaBakeryContext(IConfiguration config) : base()
        {
            this.config = config;
        }

        protected MagicCucaBakeryContext()
        {
        }

        public DbSet<T> GetSet<T>()
            where T : class
        {
            return Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (config.GetSection("DataBase").GetValue<string>("DatabaseType"))
            {                 
                case "SQLITE":
                    optionsBuilder.UseSqlite($"Data Source={config.GetSection("DataBase").GetValue<string>("Server")}", b => b.MigrationsAssembly("MagicCucaBakery.API"));
                    break;
                case "MSSQL":
                    optionsBuilder.UseSqlServer($"Data Source={config.GetSection("DataBase").GetValue<string>("Server")};Initial Catalog={config.GetSection("DataBase").GetValue<string>("DataBase")};Integrated Security=True;", b => b.MigrationsAssembly("MagicCucaBakery.API"));
                    break;
                default:
                    throw new InvalidOperationException("Wrong Database Type");
            }            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .OwnsOne(c => c.Address);

            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasKey(p => p.Id);

            modelBuilder.Entity<OrderProducts>()
                .ToTable("OrderProducts")
                .HasKey(p => p.Id);

            modelBuilder.Entity<OrderProducts>()
                .HasOne(p => p.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<OrderProducts>()
                .HasOne(p => p.Product)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer()
                {
                    Id = 1,
                    FirstName = "Customer",
                    LastName = "Default",
                    Active = true,
                    Email = "",
                    PhoneNumber = ""
                });

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { Id = 1, Name = "Cuca - Banana with white chocolate", Description = "Classic cuca Banana with white chocolate, covered with sweet farofa", Price = 25, Weight = 2, Active = true},
                    new Product() { Id = 2, Name = "Cuca - Strawberries", Description = "Cuca with strawberries, covered with sweet farofa", Price = 27, Weight = 2, Active = true },
                    new Product() { Id = 3, Name = "Cuca - chocolate", Description = "Cuca with dark chocolate, covered with sweet farofa", Price = 25, Weight = 2, Active = true },
                    new Product() { Id = 4, Name = "Cuca - Bolo-de-Rolo", Description = "Cuca special with classic Recife's desert and white chocolate, covered with sweet farofa", Price = 30, Weight = 2.5, Active = true }
                );

            modelBuilder.Entity<User>()
               .HasData(
                   new User() { Id = 1, Name = "Admin", Login = "Admin", PasswordHash =  AuthHelper.GetMd5Hash("Admin"), PasswordChange = true}                   
               );

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }      
    }
}
