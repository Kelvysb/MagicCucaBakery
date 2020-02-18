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
    public class ProductsRepository : BaseRepository<Product, ProductDto>, IProductsRepository
    {
        public ProductsRepository(IMagicCucaBakeryContext context) : base(context)
        {
        }

        public override Task<List<ProductDto>> GetAll()
        {
            return context.Products
                .Select(ProductProjection())
                .AsNoTracking()
                .ToListAsync();
        }
       
        public override Task<ProductDto> GetById(int id)
        {
            return context.Products
                .Where(p => p.Id == id)
                .Select(ProductProjection())
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<List<ProductDto>> GetByName(string name)
        {
            return context.Products
                .Where(p => p.Name.Contains(name))
                .Select(ProductProjection())
                .AsNoTracking()
                .ToListAsync();
        }

        public override Task<int> Add(Product entity)
        {
            context.Products.Add(entity);
            return context.SaveChangesAsync();
        }

        public override Task<int> Delete(int id)
        {
            context.Products.Remove(new Product() { Id = id });
            return context.SaveChangesAsync();
        }

        public override Task<int> Update(Product entity)
        {
            context.Products.Update(entity);
            return context.SaveChangesAsync();
        }

        private Expression<Func<Product, ProductDto>> ProductProjection()
        {
            return p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Weight = p.Weight
            };
        }
    }
}
