using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions
{
    public interface IProductsRepository: IBaseRepository<Product, ProductDto>
    {
        public Task<List<ProductDto>> GetByName(string name);
    }
}
