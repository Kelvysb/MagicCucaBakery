using MagicCucaBakery.Domain.Abstractions.Entities;
using System.Collections.Generic;

namespace MagicCucaBakery.Domain.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public bool Active { get; set; }

        public List<OrderProducts> OrderProducts { get; set; }
    }
}
