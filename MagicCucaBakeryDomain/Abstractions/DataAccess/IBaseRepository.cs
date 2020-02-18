using MagicCucaBakery.Domain.Abstractions.Dtos;
using MagicCucaBakery.Domain.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDto
    {
        public Task<List<TDTO>> GetAll();

        public Task<TDTO> GetById(int id);

        public Task<int> Add(TEntity entity);

        public Task<int> Update(TEntity entity);

        public Task<int> Delete(int id);
    }
}
