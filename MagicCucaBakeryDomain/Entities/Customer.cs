using MagicCucaBakery.Domain.Abstractions.Entities;
using System.Collections.Generic;

namespace MagicCucaBakery.Domain.Entities
{
    public class Customer: IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }       

        public bool Active { get; set; }

        public CustomerAddress Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
