using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {

        private IOptionService _optionService;

        public OptionsController(IOptionService optionService)
        {
            _optionService = optionService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _optionService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _optionService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.Option option)
        {
            var result = _optionService.Add(option);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.Option option)
        {
            _optionService.Update(option);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.Option option)
        {
            _optionService.Delete(option);

            return Ok();


        }


    }
}
