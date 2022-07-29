using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;
using ServiceLayer.Concrete;
using EntityLayer.Concrete;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
                 _fileService= fileService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fileService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _fileService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getlastfile")]
        public IActionResult GetBGetLastFileyId()
        {
            var result = _fileService.GetAll().Last();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.File file)
        {
            var result = _fileService.Add(file);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.File file)
        {
            _fileService.Update(file);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.File file)
        {
            _fileService.Delete(file);

            return Ok();


        }
    }

}

