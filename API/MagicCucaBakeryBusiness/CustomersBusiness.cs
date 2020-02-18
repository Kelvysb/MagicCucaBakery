using AutoMapper;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Business
{
    public class CustomersBusiness : BaseBusiness<Customer, CustomerDto, ICustomersRepository>, ICustomersBusiness
    {
        public CustomersBusiness(ICustomersRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<List<CustomerDto>> GetByName(string name)
        {
            return repository.GetByName(name);
        }
    }
}
