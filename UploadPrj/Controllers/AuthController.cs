using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public ActionResult Login(string userName,string password )
        {
            var userToLogin = _authService.Login(userName,password);
            if (!userToLogin)
            {
                return BadRequest("Username or password is incorrect");
            }

         
            else if (userToLogin)
            {
                return Ok("Login Success!");
            }

            else
            {
                return BadRequest("unknown error");
            }
        }
    }
}
