using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MagicCucaBakeryApp.Models
{
    public class Order : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Observation { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItem> Items { get; set; }

        public double ItemsTotalWeight { get; set; }

        public double TotalValue { get; set; }

        public int ItemQuantity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}