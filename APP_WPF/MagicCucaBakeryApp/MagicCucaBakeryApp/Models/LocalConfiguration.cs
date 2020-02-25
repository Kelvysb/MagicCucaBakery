using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    internal class LocalConfiguration : INotifyPropertyChanged
    {
        private string apiUri;
        private string token;
        private string userName;

        public string ApiUri
        {
            get => apiUri;
            set
            {
                apiUri = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ApiUri"));
            }
        }

        public string Token
        {
            get => token;
            set
            {
                token = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Token"));
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}