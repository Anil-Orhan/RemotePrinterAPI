using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _operationService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _operationService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.Operation operation)
        {
            var result = _operationService.Add(operation);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.Operation operation)
        {
            _operationService.Update(operation);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.Operation operation)
        {
            _operationService.Delete(operation);

            return Ok();


        }

    }
}
