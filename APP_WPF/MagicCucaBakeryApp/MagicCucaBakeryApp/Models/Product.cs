using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}