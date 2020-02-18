using AutoMapper;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using MagicCucaBakery.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using MagicCucaBakery.Domain.Helpers;

namespace MagicCucaBakery.Business
{
    public class UsersBusiness : BaseBusiness<User, UserDto, IUsersRepository>, IUsersBusiness
    {
        readonly IConfiguration config;

        public UsersBusiness(IUsersRepository repository, IMapper mapper, IConfiguration config) : base(repository, mapper)
        {
            this.config = config;
        }

        public async override Task<int> Add(UserDto dto)
        {
            User user = await repository.GetUserByLogin(dto.Login);
            if (user == null)
            {
                user = mapper.Map<User>(dto);
                user.PasswordHash = AuthHelper.GetMd5Hash(dto.Login);
                user.PasswordChange = true;
                return await repository.Add(user);                
            }
            else
            {
                throw new NotAuthorizedException(dto.Login);
            }
        }

        public async Task<bool> ChangePassword(LoginDto login)
        {
            User user = await repository.GetUser(login.User.Id);
            if(user.PasswordHash.Equals(login.Password, StringComparison.InvariantCultureIgnoreCase))
            {
                user.PasswordHash = login.NewPassword;
                await repository.Update(user);
                return true;
            }
            else
            {
                throw new NotAuthorizedException(login.Login);
            }
        }

        public async Task<LoginDto> Login(LoginDto login)
        {
            User user = await repository.GetUserByLogin(login.Login);
            if (user != null && user.PasswordHash.Equals(login.Password, StringComparison.InvariantCultureIgnoreCase))
            {
                LoginDto result = new LoginDto();
                result.User = mapper.Map<UserDto>(user);
                result.Token = AuthHelper.GetToken(user.Id.ToString(), 
                    config.GetSection("Auth").GetValue<string>("Secret"), 
                    config.GetSection("Auth").GetValue<string>("Issuer"));
                return result;
            }
            else
            {
                throw new NotAuthorizedException(login.Login);
            }
        }                  
    }
}
