using MagicCucaBakery.Domain.Abstractions.Dtos;

namespace MagicCucaBakery.Domain.Dtos
{
    public class UserDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public bool PasswordChange { get; set; }
    }
}
