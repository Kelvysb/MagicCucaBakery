namespace MagicCucaBakery.Domain.Dtos
{
    public class LoginDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public UserDto User { get; set; }

        public string Token { get; set; }
    }
}
