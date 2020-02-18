using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Abstractions.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MagicCucaBakery.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("/[controller]")]
    public abstract class BaseController<TDTO, TBusiness> : ControllerBase
        where TBusiness : IBaseBusiness<TDTO>
        where TDTO : IDto
    {
        protected readonly TBusiness business;

        protected BaseController(TBusiness business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async virtual Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            try
            {
                var result = await business.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetAll()
        {
            try
            {
                var result = await business.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async virtual Task<IActionResult> Add([FromBody]TDTO dto)
        {
            try
            {
                var result = await business.Add(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async virtual Task<IActionResult> Update([FromBody]TDTO dto)
        {
            try
            {
                var result = await business.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var result = await business.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
