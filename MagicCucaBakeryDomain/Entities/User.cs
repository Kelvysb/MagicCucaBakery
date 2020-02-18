using MagicCucaBakery.Domain.Abstractions.Entities;

namespace MagicCucaBakery.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool PasswordChange { get; set; }
    }
}
