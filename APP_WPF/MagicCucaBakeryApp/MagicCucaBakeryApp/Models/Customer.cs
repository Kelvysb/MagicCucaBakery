using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class Customer : INotifyPropertyChanged
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

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }


        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
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

        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }

        private bool active;
        public bool Active
        {
            get => active;
            set
            {
                active = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Active"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}