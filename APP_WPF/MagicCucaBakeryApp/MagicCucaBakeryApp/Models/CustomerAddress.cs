using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class CustomerAddress : INotifyPropertyChanged
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}