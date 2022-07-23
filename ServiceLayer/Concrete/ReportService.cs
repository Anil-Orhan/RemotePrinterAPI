using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public  class ReportService : IReportService
    {
        private IUserService _userService;
        private IPrinterService _printerService;
        private IFileService _fileService;
        private IAuthService _authService;
        private IUserLogDal _userLogDal;



     public ReportService(IUserService userService, IPrinterService printerService,
             IFileService fileService, IAuthService authService,IUserLogDal userLogDal)
        {
           
                _fileService=fileService;
                _printerService=printerService;
                _userService=userService;
                _authService=   authService;
                _userLogDal=userLogDal;
                

        }

     public void CreateUserLog(PrintModel printModel)
     {
         UserLogDto user = new UserLogDto() {
             PrinterId = printModel.PrinterId,
             PrinterName =_printerService.GetById(printModel.PrinterId).PrinterName,
             PrintDate = printModel.Date,
             UserFullName = _userService.GetById(printModel.UserId).name+" "+ _userService.GetById(printModel.UserId).lastName,
             FileId = printModel.FileId,
             UserId = printModel.UserId,
             UserName = _userService.GetById(printModel.UserId).userName


         };
         _userLogDal.Add(user);
     }


     public List<UserLogDto> UserLogDto()
     {
         return _userLogDal.GetAll();
     }



    }
}
