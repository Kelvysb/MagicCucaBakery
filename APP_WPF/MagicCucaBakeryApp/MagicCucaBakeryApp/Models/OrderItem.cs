using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class OrderItem : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public int Quantity { get; set; }

        public string Observation { get; set; }

        public ProductStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}