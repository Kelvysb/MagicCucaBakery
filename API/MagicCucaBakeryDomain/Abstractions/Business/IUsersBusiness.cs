using MagicCucaBakery.Domain.Dtos;
using System.Threading.Tasks;

namespace MagicCucaBakery.Domain.Abstractions.Business.Abstractions
{
    public interface IUsersBusiness : IBaseBusiness<UserDto>
    {
        public Task<LoginDto> Login(LoginDto login);

        public Task<bool> ChangePassword(LoginDto login);
    }
}
