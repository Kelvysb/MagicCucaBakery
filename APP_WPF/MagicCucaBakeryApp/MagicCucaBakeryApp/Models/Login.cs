using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class Login : INotifyPropertyChanged
    {
        public string UserLogin { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public User User { get; set; }

        public string Token { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}