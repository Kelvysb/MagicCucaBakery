using System;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.Dtos;
using MagicCucaBakery.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MagicCucaBakery.API.Controllers
{
    public class UsersController : BaseController<UserDto, IUsersBusiness>
    {
        public UsersController(IUsersBusiness business) : base(business)
        {
        }
                
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]LoginDto login)
        {
            try
            {
                var result = await business.ChangePassword(login);
                return Ok(result);
            }
            catch (NotAuthorizedException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            try
            {
                var result = await business.Login(login);
                return Ok(result);
            }
            catch (NotAuthorizedException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}