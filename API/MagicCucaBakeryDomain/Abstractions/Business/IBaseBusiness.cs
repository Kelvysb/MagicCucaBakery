using MagicCucaBakery.Domain.Abstractions.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.Abstractions.Business.Abstractions
{
    public interface IBaseBusiness<TDTO>
        where TDTO : IDto
    {
        public Task<TDTO> GetById(int id);

        public Task<List<TDTO>> GetAll();

        public Task<int> Add(TDTO dto);

        public Task<int> Update(TDTO dto);

        public Task<int> Delete(int id);
    }
}
