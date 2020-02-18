using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions
{
    public interface ICustomersRepository : IBaseRepository<Customer, CustomerDto>
    {
        public Task<List<CustomerDto>> GetByName (string name);
    }
}
