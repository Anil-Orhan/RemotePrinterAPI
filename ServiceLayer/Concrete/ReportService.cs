using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public  class ReportService : IReportService
    {
        //private IUserService _userService;
        //private IPrinterService _printerService;
        //private IFileService _fileService;
        //private IAuthService _authService;
      
        


         ReportService(IUserService userService, IPrinterService printerService,
             IFileService fileService, IAuthService authService)
        {
            //_fileService = fileService;
            //_userService = userService;
            //_printerService = printerService;
           
            //_authService = authService;
          

        }

      
      //public  UserLogDto UserLogCreate(PrintModel printModel)
      //{
      //    UserLogDto userLog = new UserLogDto();
      //      var user = _userService.GetById(_authService.GetActiveUserId());
          
      //      if (user != null)
      //      {


      //          userLog.PrintDate = printModel.Date;
      //          userLog.UserId = user.id;
      //          userLog.PrintDate=printModel.Date;
      //          userLog.FileId = printModel.FileId;

            
      //          return userLog;
      //      }
      //      else
      //      {
      //          throw new Exception("User Not Faund");
      //      }


      //  }
    }
}
