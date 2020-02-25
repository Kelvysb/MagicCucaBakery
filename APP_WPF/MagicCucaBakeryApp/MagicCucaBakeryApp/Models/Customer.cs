using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CustomerAddress Address { get; set; }

        public bool Active { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}