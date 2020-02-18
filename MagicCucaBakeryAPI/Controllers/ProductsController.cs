using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MagicCucaBakery.API.Controllers
{
    public class ProductsController : BaseController<ProductDto, IProductsBusiness>
    {
        public ProductsController(IProductsBusiness business) : base(business)
        {
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            try
            {
                var result = await business.GetByName(name);
                return Ok(result);
            }            
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}