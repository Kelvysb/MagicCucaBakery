using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}