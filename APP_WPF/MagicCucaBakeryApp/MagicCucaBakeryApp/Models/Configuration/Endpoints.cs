using System.ComponentModel;

namespace MagicCucaBakeryApp.Models.Configuration
{
    internal class Endpoints : INotifyPropertyChanged
    {        
        private UserEndpoints users;
        public UserEndpoints Users
        {
            get => users;
            set
                {
                    users = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Users"));
            }
        }
        
        private OrderEndpoints orders;
        public OrderEndpoints Orders
        {
            get => orders;
            set
                {
                    orders = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
            }
        }

        private ProductEndpoints products;
        public ProductEndpoints Products
        {
            get => products;
            set
                {
                    products = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Products"));
            }
        }
        
        private CustomerEndpoints customers;
        public CustomerEndpoints Customers
        {
            get => customers;
            set
                {
                    customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}