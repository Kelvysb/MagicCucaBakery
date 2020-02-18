using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions
{
    public interface IOrdersRepository: IBaseRepository<Order, OrderDto>
    {
        Task<int> AddItem(OrderProducts item);

        Task<int> UpdateItem(OrderProducts item);

        Task<int> RemoveItem(int itemId);
    }
}
