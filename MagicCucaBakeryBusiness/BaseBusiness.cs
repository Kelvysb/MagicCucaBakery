using AutoMapper;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Abstractions.Dtos;
using MagicCucaBakery.Domain.Abstractions.Entities;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicCucaBakery.Business
{
    public class BaseBusiness<TEntity, TDTO, TRepository> : IBaseBusiness<TDTO>
        where TRepository : IBaseRepository<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDto
    {
        protected readonly TRepository repository;
        protected readonly IMapper mapper;

        public BaseBusiness(TRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual Task<List<TDTO>> GetAll()
        {
            return repository.GetAll();
        }

        public virtual Task<TDTO> GetById(int id)
        {
            return repository.GetById(id);
        }
        public virtual Task<int> Add(TDTO dto)
        {
            dto.Id = 0;
            return repository.Add(mapper.Map<TEntity>(dto));
        }

        public virtual Task<int> Delete(int id)
        {
            return repository.Delete(id);
        }

        public virtual Task<int> Update(TDTO dto)
        {
            return repository.Update(mapper.Map<TEntity>(dto));
        }
    }
}
