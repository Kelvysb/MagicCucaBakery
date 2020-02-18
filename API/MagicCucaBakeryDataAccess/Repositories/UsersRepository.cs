using MagicCucaBakery.Domain.DataAccess.Context.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagicCucaBakery.DataAccess.Repositories
{
    public class UsersRepository : BaseRepository<User, UserDto>, IUsersRepository
    {
        public UsersRepository(IMagicCucaBakeryContext context) : base(context)
        {
        }

        public override Task<List<UserDto>> GetAll()
        {
            return context.Users
                .Select(UserProjection())
                .ToListAsync();
        }        

        public override Task<UserDto> GetById(int id)
        {
            return context.Users
                .Where(c => c.Id == id)
                .Select(UserProjection())
                .FirstOrDefaultAsync();
        }

        public Task<User> GetUser(int id)
        {
            return context.Users
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByLogin(string login)
        {
            return context.Users
                .Where(c => c.Login.Equals(login))
                .FirstOrDefaultAsync();
        }

        public override Task<int> Add(User entity)
        {
            context.Users.Add(entity);
            return context.SaveChangesAsync();
        }

        public override Task<int> Delete(int id)
        {
            context.Users.Remove(new User() { Id = id});
            return context.SaveChangesAsync();
        }

        public override Task<int> Update(User entity)
        {
            context.Users.Update(entity);
            return context.SaveChangesAsync();
        }

        private Expression<Func<User, UserDto>> UserProjection()
        {
            return c => new UserDto()
            {
                Id = c.Id,
                Name = c.Name,
                Login = c.Login,
                Email = c.Email,
                PasswordChange = c.PasswordChange
            };
        }
    }
}
