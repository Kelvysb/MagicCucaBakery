using System.ComponentModel;

namespace MagicCucaBakeryApp.Models.Configuration
{
    internal abstract class EndpointsBase : INotifyPropertyChanged
    {
        private string all;
        public string All
        {
            get => all;
            set
                {
                    all = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("All"));
            }
        }

        private string byId;
        public string ById
        {
            get => byId;
            set
                {
                    byId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ById"));
            }
        }
        
        private string update;
        public string Update
        {
            get => update;
            set
                {
                    update = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Update"));
            }
        }
        
        private string insert;
        public string Insert
        {
            get => insert;
            set
                {
                    insert = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Insert"));
            }
        }
        
        private string delete;
        public string Delete
        {
            get => delete;
            set
                {
                    delete = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Delete"));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}