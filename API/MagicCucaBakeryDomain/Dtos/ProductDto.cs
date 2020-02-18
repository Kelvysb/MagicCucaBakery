using MagicCucaBakery.Domain.Abstractions.Dtos;

namespace MagicCucaBakery.Domain.Dtos
{
    public class ProductDto: IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }
    }
}
