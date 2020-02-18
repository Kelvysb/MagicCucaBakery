using MagicCucaBakery.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.Abstractions.Business.Abstractions
{
    public interface ICustomersBusiness: IBaseBusiness<CustomerDto>
    {
        public Task<List<CustomerDto>> GetByName(string name);
    }
}
