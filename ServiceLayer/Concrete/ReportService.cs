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
        private IOperationService _operationService;
        private IWalletService _walletService;



     public ReportService(IUserService userService, IPrinterService printerService,
                IFileService fileService, IAuthService authService, IUserLogDal userLogDal, IOperationService operationService,IWalletService walletService)
        {

            _fileService = fileService;
            _printerService = printerService;
            _userService = userService;
            _authService = authService;
            _userLogDal = userLogDal;
            _operationService = operationService;
            _walletService = walletService;
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


        public List<UserLogDto> GetAll()
        {
         return _userLogDal.GetAll();
        }

        public UserDetailReportDto UserDetailReport(Guid id,int filterDay)
        {
            var user=_userService.GetById(id);
           var wallet= _walletService.GetById(user.WalletId);
            var totalexpense = _operationService.TotalExpense(id);

       

            UserDetailReportDto userDetailReport = new UserDetailReportDto() 
            {userId=id ,
                userName=user.userName,userFullName=user.name+" "+user.lastName,
                TotalBalance=wallet.Balance,TotalExpense=totalexpense,
                TotalPageAmounth=10,// Default Value 
                IncorrectTransactionAmount=0,//Default Value
                DatedTransactionAmount=_operationService.TotalProcessWithDate(id,filterDay)

              
                
            };
            return userDetailReport;
        }

        public UserLogDto UserLogDtoById(Guid id)
        {
            return _userLogDal.Get(p=>p.Id==id);
        }
    }
}
