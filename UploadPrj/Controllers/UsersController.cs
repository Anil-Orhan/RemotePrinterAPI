using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;
using System.Text.Json;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userManager;
        private IReportService _reportService;

        public UsersController(IUserService userManager, IReportService reportService)
        {
            _userManager = userManager;
            _reportService = reportService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            if (result !=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _userManager.GetById(id);
            if (result !=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            _userManager.Update(user);
        
                return Ok();
         
          
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
           _userManager.Delete(user);
          
                return Ok();
          
           
        }

        [HttpGet("getdetailbyid")]
        public IActionResult GetDetailById(Guid id)
        {
            var result = _reportService.UserLogDtoById(id);
           
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
