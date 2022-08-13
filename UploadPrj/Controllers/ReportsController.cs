using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("logbyid")]
        public IActionResult LogById(Guid id)
        {
            var result = _reportService.UserLogDtoById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _reportService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailbyid")]
        public IActionResult GetUserDetailById(Guid id,int filterDay)
        {
            var result = _reportService.UserDetailReport(id,filterDay);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
