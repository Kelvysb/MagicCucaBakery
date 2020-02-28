using System.ComponentModel;

namespace MagicCucaBakeryApp.Models.Configuration
{
    internal class UserEndpoints : EndpointsBase, INotifyPropertyChanged
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
        
        private string changePassword;
        public string ChangePassword
        {
            get => changePassword;
            set
                {
                    changePassword = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ChangePassword"));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}