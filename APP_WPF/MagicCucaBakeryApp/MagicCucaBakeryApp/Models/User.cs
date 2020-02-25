using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public bool PasswordChange { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}