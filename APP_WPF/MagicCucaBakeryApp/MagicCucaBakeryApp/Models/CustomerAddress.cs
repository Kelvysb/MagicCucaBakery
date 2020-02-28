using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class CustomerAddress : INotifyPropertyChanged
    {
        private string street;
        public string Street
        {
            get => street;
            set
                {
                    street = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Street"));
            }
        }
        
        private string number;
        public string Number
        {
            get => number;
            set
                {
                    number = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Number"));
            }
        }

        private string complement;
        public string Complement
        {
            get => complement;
            set
                {
                    complement = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Complement"));
            }
        }
        
        private string neighborhood;
        public string Neighborhood
        {
            get => neighborhood;
            set
                {
                    neighborhood = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Neighborhood"));
            }
        }
        
        private string postalCode;
        public string PostalCode
        {
            get => postalCode;
            set
                {
                    postalCode = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PostalCode"));
            }
        }
        
        private string city;
        public string City
        {
            get => city;
            set
                {
                    city = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("City"));
            }
        }
        
        private string state;
        public string State
        {
            get => state;
            set
                {
                    state = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}