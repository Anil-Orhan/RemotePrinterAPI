using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {

        private IPrinterService _printerService;

        public PrinterController(IPrinterService printerService)
        {
            _printerService = printerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _printerService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _printerService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.Printer printer)
        {
            var result = _printerService.Add(printer);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.Printer printer)
        {
            _printerService.Update(printer);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.Printer printer)
        {
            _printerService.Delete(printer);

            return Ok();


        }

    }
}
