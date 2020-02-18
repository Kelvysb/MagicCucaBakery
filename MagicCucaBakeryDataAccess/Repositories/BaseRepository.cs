using MagicCucaBakery.Domain.Abstractions.Dtos;
using MagicCucaBakery.Domain.Abstractions.Entities;
using MagicCucaBakery.Domain.DataAccess.Context.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TDTO> : IBaseRepository<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDto
    {
        protected IMagicCucaBakeryContext context;
        
        protected BaseRepository(IMagicCucaBakeryContext context)
        {
            this.context = context;
        }

        public abstract Task<int> Add(TEntity entity);

        public abstract Task<int> Delete(int id);

        public abstract Task<List<TDTO>> GetAll();

        public abstract Task<TDTO> GetById(int id);

        public abstract Task<int> Update(TEntity entity);
    }
}
