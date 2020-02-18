using MagicCucaBakery.Domain.Common;

namespace MagicCucaBakery.Domain.Entities
{
    public class OrderProducts
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Observation { get; set; }

        public ProductStatus Status { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
