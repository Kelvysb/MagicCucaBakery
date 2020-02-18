using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions
{
    public interface IUsersRepository : IBaseRepository<User, UserDto>
    {
        public Task<User> GetUser(int id);
        Task<User> GetUserByLogin(string login);
    }
}
