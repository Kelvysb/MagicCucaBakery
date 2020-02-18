using MagicCucaBakery.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.Abstractions.Business.Abstractions
{
    public interface IProductsBusiness: IBaseBusiness<ProductDto>
    {
        public Task<List<ProductDto>> GetByName(string name);
    }
}
