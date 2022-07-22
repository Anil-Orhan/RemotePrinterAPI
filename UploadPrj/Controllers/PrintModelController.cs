using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintModelController : ControllerBase
    {

        private IPrintModelService _printModelService;

        public PrintModelController(IPrintModelService printModelService)
        {
            _printModelService = printModelService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _printModelService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _printModelService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.PrintModel printModel)
        {
            var result = _printModelService.Add(printModel);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.PrintModel printModel)
        {
            _printModelService.Update(printModel);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.PrintModel printModel)
        {
            _printModelService.Delete(printModel);

            return Ok();


        }

    }
}
