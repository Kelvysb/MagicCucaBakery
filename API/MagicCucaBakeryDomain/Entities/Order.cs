using MagicCucaBakery.Domain.Abstractions.Entities;
using MagicCucaBakery.Domain.Common;
using System;
using System.Collections.Generic;

namespace MagicCucaBakery.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public OrderStatus Status { get; set; }

        public string Observation { get; set; }

        public List<OrderProducts> OrderProducts { get; set; }
    }
}
