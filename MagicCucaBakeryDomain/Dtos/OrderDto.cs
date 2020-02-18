using MagicCucaBakery.Domain.Abstractions.Dtos;
using MagicCucaBakery.Domain.Common;
using System;
using System.Collections.Generic;

namespace MagicCucaBakery.Domain.Dtos
{
    public class OrderDto: IDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Observation { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public double ItemsTotalWeight { get; set; }

        public double TotalValue { get; set; }

        public int ItemQuantity { get; set; }
    }
}
