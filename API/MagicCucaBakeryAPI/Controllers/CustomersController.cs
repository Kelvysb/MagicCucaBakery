using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MagicCucaBakery.API.Controllers
{
    [Authorize]
    public class CustomersController : BaseController<CustomerDto, ICustomersBusiness>
    {
        public CustomersController(ICustomersBusiness business) : base(business)
        {
        }

        [HttpGet("name")]
        public async virtual Task<IActionResult> GetByName([FromQuery]string name)
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