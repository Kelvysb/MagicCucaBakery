using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MagicCucaBakery.API.Controllers
{
    [Authorize]
    public class OrdersController : BaseController<OrderDto, IOrdersBusiness>
    {
        public OrdersController(IOrdersBusiness business) : base(business)
        {
        }

        [HttpPost("{orderId}/Item")]
        public async Task<IActionResult> AddItem([FromRoute]int orderId, [FromBody]OrderItemDto item)
        {
            try
            {
                var result = await business.AddItem(orderId, item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Item/{itemId}")]
        public async Task<IActionResult> RemoveItem([FromRoute]int itemId)
        {
            try
            {
                var result = await business.RemoveItem(itemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{orderId}/Item")]
        public async Task<IActionResult> UpdateItem([FromRoute]int orderId, [FromBody]OrderItemDto item)
        {
            try
            {
                var result = await business.UpdateItem(orderId, item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}