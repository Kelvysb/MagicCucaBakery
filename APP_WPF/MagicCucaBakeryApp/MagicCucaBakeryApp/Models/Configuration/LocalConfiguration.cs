using System.ComponentModel;

namespace MagicCucaBakeryApp.Models.Configuration
{
    internal class LocalConfiguration : INotifyPropertyChanged
    {
        private string apiUri;
        public string ApiUri
        {
            get => apiUri;
            set
            {
                apiUri = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ApiUri"));
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

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        private Endpoints endpoints;
        public Endpoints Endpoints
        {
            get => endpoints;
            set
                {
                    endpoints = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Endpoints"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}