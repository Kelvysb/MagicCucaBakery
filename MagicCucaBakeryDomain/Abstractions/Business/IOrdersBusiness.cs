using MagicCucaBakery.Domain.Dtos;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.Abstractions.Business.Abstractions
{
    public interface IOrdersBusiness: IBaseBusiness<OrderDto>
    {
        Task<int> AddItem(int orderId, OrderItemDto item);

        Task<int> UpdateItem(int orderId, OrderItemDto item);

        Task<int> RemoveItem(int itemId);
    }
}
