using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Authentication;
using ShopOnline.Models.Models;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var isAuthenticated = await _authenticationService.RegisterUser(registerModel);
                if (!isAuthenticated)
                    return BadRequest("Not Authenticated");

                return Ok(isAuthenticated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
