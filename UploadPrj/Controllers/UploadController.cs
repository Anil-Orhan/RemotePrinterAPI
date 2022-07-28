using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using ServiceLayer.Abstract;
using UploadPrj.Utilities;
using File = EntityLayer.Concrete.File;


namespace UploadPrj.Controllers
{
    
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IFileService _fileService;
        private IOptionService _optionService;
        //Test
        public UploadController(IFileService fileService, IOptionService optionService)
        {
            _fileService = fileService;
            _optionService = optionService;
        }
        [HttpPost]
        [Route("savefile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            await WriteFile(file);
          
            return Ok();


        }
            private async Task<bool> WriteFile(IFormFile file)
            {
                string fileFullName = file.FileName;
                bool isSaveSuccess = false;
                FileInfo fi = new FileInfo(file.FileName);
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
                    double fileSize = file.Length;
                EntityLayer.Concrete.File fileC = new EntityLayer.Concrete.File(){FileUrl = path,CloudUrl = "CLOUD-URL",UserId =Guid.Parse("b21972e1-742f-4fa7-be46-1189d9cab7ca"),
                        CreateDate = DateTime.Now,FileName = fileFullName,FileExtension = extension,FileSize =
                           Math.Round(((((double)fileSize) / 1024) / 1024), 2),PageNumber = 1};
                List<File> files = new List<File>();
                files.Add(fileC);
                var result=CreateOptionModel(files);
                _optionService.AddOptionForOperation(result.Option,result.User,result.Files,result.Printer);
                //_fileService.Add(fileC); tekli





                }
                catch (Exception)
                {

                    throw;
                }
                return isSaveSuccess;
                 OptionControllerEntityDto CreateOptionModel(List<File> files)
                {
                    Printer printer = new Printer { Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Brand = null, PrinterName = null, Model = null, Coordinate = "null", PrinterIP = null };
                    Option option = new Option() { Colorless = 3, Colored = 5, PageNumber = 5, Amount = 15 };
                    if (StaticValues.ActiveUser==null)
                    {
                        throw new Exception("There is no user logged into the system!") {  };
                    }
                    else
                    {
                    OptionControllerEntityDto optionController = new OptionControllerEntityDto { User = StaticValues.ActiveUser, Files = files, Printer = printer, Option = option };
                    return optionController;
                }
                    

                }

        }

            public void Send(string file)
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = @"C:\Users\Vodases\Desktop\Printerapo_Api\clientsocket\bin\Debug\clientsocket.exe";
                    process.StartInfo.Arguments = $"{file}";
                    //process.StartInfo.FileName = @"cmd.exe";
                    //process.StartInfo.Arguments = @"/c dir";     
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
                    process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
                    Console.WriteLine("starting");
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    var exited = process.WaitForExit(1000 * 10);
                    Console.WriteLine($"exit {exited}");
                }

                // Clients.All.SendAsync("OnMessage", file);
            }


    }

}
