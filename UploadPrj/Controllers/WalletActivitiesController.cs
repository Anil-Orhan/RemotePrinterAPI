using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;

namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletActivitiesController : ControllerBase
    {
        private IWalletActivityService _walletActivityService;

        public WalletActivitiesController(IWalletActivityService walletActivityService)
        {
            _walletActivityService = walletActivityService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _walletActivityService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _walletActivityService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EntityLayer.Concrete.WalletActivity walletActivity)
        {
            var result = _walletActivityService.Add(walletActivity);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EntityLayer.Concrete.WalletActivity walletActivity)
        {
            _walletActivityService.Update(walletActivity);

            return Ok();


        }

        [HttpPost("delete")]
        public IActionResult Delete(EntityLayer.Concrete.WalletActivity walletActivity)
        {
            _walletActivityService.Delete(walletActivity);

            return Ok();


        }




    }
}
