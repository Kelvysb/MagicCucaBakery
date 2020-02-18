using AutoMapper;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Threading.Tasks;

namespace MagicCucaBakery.Business
{
    public class OrdersBusiness : BaseBusiness<Order, OrderDto, IOrdersRepository>, IOrdersBusiness
    {
        public OrdersBusiness(IOrdersRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }       

        public async override Task<int> Update(OrderDto dto)
        {
            Order entity = mapper.Map<Order>(dto);
            OrderDto actualDTO = await repository.GetById(entity.Id);
            entity.CreationDate = actualDTO.CreationDate;
            return await base.Update(dto);
        }

        public async Task<int> AddItem(int orderId, OrderItemDto item)
        {
            OrderProducts entity = mapper.Map<OrderProducts>(item);
            entity.OrderId = orderId;
            return await repository.AddItem(entity);
        }

        public async Task<int> RemoveItem(int itemId)
        {
            return await repository.RemoveItem(itemId);
        }

        public async Task<int> UpdateItem(int orderId, OrderItemDto item)
        {
            OrderProducts entity = mapper.Map<OrderProducts>(item);
            entity.OrderId = orderId;
            return await repository.UpdateItem(entity);
        }
    }
}
