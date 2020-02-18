using MagicCucaBakery.Domain.Abstractions.Dtos;

namespace MagicCucaBakery.Domain.Dtos
{
    public class CustomerDto: IDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CustomerAddressDto Address { get; set; }

        public bool Active { get; set; }
    }
}
