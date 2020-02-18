using AutoMapper;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Business
{
    public class ProductsBusiness : BaseBusiness<Product, ProductDto, IProductsRepository>, IProductsBusiness
    {
        public ProductsBusiness(IProductsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<List<ProductDto>> GetByName(string name)
        {
            return repository.GetByName(name);
        }
    }
}
