using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;


namespace UploadPrj.Controllers
{
    
    [ApiController]
    public class UploadController : ControllerBase
    {


            [HttpPost]
            [Route("savefile")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> UploadFile(IFormFile file,CancellationToken cancellationToken) { await WriteFile(file); return Ok(); }
            private async Task<bool> WriteFile(IFormFile file)
            {
                bool isSaveSuccess = false;

                string fileName;
                try
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split(".").Length - 1];

                    fileName = DateTime.Now.Ticks + extension;
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Folders");
                    if (Directory.Exists(pathBuilt)) { Directory.CreateDirectory(pathBuilt); }
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Folders", fileName);
                    using (var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                    isSaveSuccess = true;

                }
                catch (Exception)
                {

                    throw;
                }
                return isSaveSuccess;


            }




    }
}
