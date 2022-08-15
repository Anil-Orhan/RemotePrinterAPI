using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using ServiceLayer.Abstract;
using UploadPrj.Utilities;
using File = EntityLayer.Concrete.File;


namespace UploadPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IFileService _fileService;
        private IOptionService _optionService;
        private IWalletService _walletService;

        private IUserService _userService;
        private List<File> _files;
        private File _file;
        //Test
        public UploadController(IFileService fileService, IOptionService optionService,IWalletService walletService,IUserService userService)
        {
            _fileService = fileService;
            _optionService = optionService;
            _walletService = walletService;
            _userService = userService;
            //Geçici Aktif Kullanıcı
            //Bakiye İşlemleri Buraya Verilen Kullanıcı ID Üzerinden Yapılacak
            var user = _userService.GetById(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ada6"));
            StaticValues.ActiveUser=user;
            _files = _fileService.GetAll();
           
            
            
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
            _file = new File();
            //_files = new List<File>();

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
               _file = new EntityLayer.Concrete.File(){Id=Guid.NewGuid(),FileUrl = path,CloudUrl = "CLOUD-URL",UserId =StaticValues.ActiveUser.id,
                        CreateDate = DateTime.Now,FileName = fileFullName,FileExtension = extension,FileSize =
                           Math.Round(((((double)fileSize) / 1024) / 1024), 2),PageNumber = 1};
                
            
                
               // _files.Add(_file);
               
                _fileService.Add(_file);





                }
                catch (Exception)
                {

                    throw;
                }
                return isSaveSuccess;
                
                    

                }



        [HttpGet("printFile")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PrintFile(CancellationToken cancellationToken)
        {
            var fileList = _fileService.GetAll();

            foreach (var item in fileList)
            {

                Send(item.FileUrl);



            }

            if (fileList.Count>0)
            {
                return Ok();
            }

            else
            {
                return BadRequest("Yazdırma işlemi için bir dosya yüklemelisiniz!");
            }
            

        }

        void Send(string yol)
        {
            var walletId = StaticValues.ActiveUser.WalletId;
            var wallet = _walletService.GetById(walletId);
            var result = CreateOptionModel(_files);
            _optionService.AddOptionForOperation(result.Option, result.User, result.Files, result.Printer);
            if (wallet.Balance >= 5)
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = @"C:\Users\Vodases\Desktop\PrintOmi15081129\backend\ClientSocket\bin\Debug\ClientSocket.exe";
                    process.StartInfo.Arguments = yol;
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
                wallet.Balance -= 5;
                _walletService.Update(wallet);
                


            }
            else
            {
                throw new Exception("Bakiyeniz Yetersiz");
            }

            OptionControllerEntityDto CreateOptionModel(List<File> files)
            {
                Printer printer = new Printer { Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Brand = null, PrinterName = null, Model = null, Coordinate = "null", PrinterIP = null };
                Option option = new Option() { Colorless = 3, Colored = 5, PageNumber = 5, Amount = 15 };
                if (StaticValues.ActiveUser == null)
                {
                    throw new Exception("There is no user logged into the system!") { };
                }
                else
                {

                    OptionControllerEntityDto optionController = new OptionControllerEntityDto { User = StaticValues.ActiveUser, Files = files, Printer = printer, Option = option };
                    return optionController;
                }

                // Clients.All.SendAsync("OnMessage", file);
            }

        }
    }


        //public void Send(string file)
        //{
        //    using (var process = new Process())
        //    {
        //        process.StartInfo.FileName = @"C:\Users\Vodases\Desktop\Printerapo_Api\clientsocket\bin\Debug\clientsocket.exe";
        //        process.StartInfo.Arguments = $"{file}";
        //        //process.StartInfo.FileName = @"cmd.exe";
        //        //process.StartInfo.Arguments = @"/c dir";     
        //        process.StartInfo.CreateNoWindow = true;
        //        process.StartInfo.UseShellExecute = false;
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.StartInfo.RedirectStandardError = true;

        //        process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
        //        process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
        //        Console.WriteLine("starting");
        //        process.Start();
        //        process.BeginOutputReadLine();
        //        process.BeginErrorReadLine();
        //        var exited = process.WaitForExit(1000 * 10);
        //        Console.WriteLine($"exit {exited}");
        //    }


        //    // Clients.All.SendAsync("OnMessage", file);
        //}


      





}




//public void Send(string file)
//{
//    using (var process = new Process())
//    {
//        process.StartInfo.FileName = @"C:\Users\Vodases\Desktop\Printerapo_Api\clientsocket\bin\Debug\clientsocket.exe";
//        process.StartInfo.Arguments = $"{file}";
//        //process.StartInfo.FileName = @"cmd.exe";
//        //process.StartInfo.Arguments = @"/c dir";     
//        process.StartInfo.CreateNoWindow = true;
//        process.StartInfo.UseShellExecute = false;
//        process.StartInfo.RedirectStandardOutput = true;
//        process.StartInfo.RedirectStandardError = true;

//        process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
//        process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
//        Console.WriteLine("starting");
//        process.Start();
//        process.BeginOutputReadLine();
//        process.BeginErrorReadLine();
//        var exited = process.WaitForExit(1000 * 10);
//        Console.WriteLine($"exit {exited}");
//    }

//    // Clients.All.SendAsync("OnMessage", file);
//}



// Clients.All.SendAsync("OnMessage", file);






