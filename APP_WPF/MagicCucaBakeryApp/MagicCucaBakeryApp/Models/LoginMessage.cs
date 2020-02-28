using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class LoginMessage : INotifyPropertyChanged
    {
        private string login;
        public string Login
        {
            get => login;
            set
                {
                    login = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Login"));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
                {
                    password = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        
        private string newPassword;
        public string NewPassword
        {
            get => newPassword;
            set
                {
                    newPassword = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("NewPassword"));
            }
        }
        
        private User user;
        public User User
        {
            get => user;
            set
                {
                    user = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("User"));
            }
        }
        
        private string token;
        public string Token
        {
            get => token;
            set
                {
                    token = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Token"));
            }
        }   

        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}