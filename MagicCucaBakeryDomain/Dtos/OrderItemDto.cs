using MagicCucaBakery.Domain.Common;

namespace MagicCucaBakery.Domain.Dtos
{
    public class OrderItemDto
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
    }
}
