using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class User : INotifyPropertyChanged
    {


        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }


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



        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }


        public bool PasswordChange { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}