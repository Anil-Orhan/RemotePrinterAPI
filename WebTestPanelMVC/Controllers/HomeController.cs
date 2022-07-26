using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceLayer.Abstract;
using WebTestPanelMVC.Models;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace WebTestPanelMVC.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IPrinterService _printerService;
        private IPrintModelService _printModelService;
        private IFileService _fileService;
        private IReportService _reportService;
        private IOptionService _optionService;
        private IOperationService _operationService;
        private IWalletActivityService _walletActivityService;
        private IWalletService _walletService;


        private AllListModel _model;
        
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger, IUserService userService,
            IPrinterService printerService, IPrintModelService printModelService,
            IFileService fileService, IReportService reportService, IOptionService optionSrService, IOperationService operationService, IWalletActivityService walletActivityService, IWalletService walletService)
        {
            _logger = logger;
            _userService = userService;
            _printerService = printerService;
            _printModelService = printModelService;
            _fileService = fileService;
            _reportService = reportService;
            _optionService = optionSrService;
           
            _operationService = operationService;
            _walletActivityService = walletActivityService;
            _walletService = walletService;
            _model = new AllListModel();
            getAllList();
        }

        public AllListModel getAllList()
        {

            _model.PrintModels = _printModelService.GetAll();
            _model.Files=_fileService.GetAll();
            _model.Printers=_printerService.GetAll();
            _model.Users=_userService.GetAll();
            _model.UserLogs = _reportService.UserLogDto();
            _model.WalletActivities=_walletActivityService.GetAll();
            _model.Wallets=_walletService.GetAll();
            _model.Options=_optionService.GetAll();
            _model.Operations=_operationService.GetAll();
            

            return _model;
        }
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            
            return View(_model);
        }
      
        


        public IActionResult Logs()
        {
            return View(_model);
        }
        public IActionResult Users()
        {
            return View(_model);
        }
        public IActionResult Printers()
        {
            return View(_model);
        }
        public IActionResult Files()
        {
            return View(_model);
        }
        public IActionResult Prints()
        {
            return View(_model);
        }
        public IActionResult Tables()
        {
            return View(_model);
        }
        public IActionResult Options()
        {
            return View(_model);
        }
        public IActionResult Operations()
        {
            return View(_model);
        }
        public IActionResult Wallets()
        {
            return View(_model);
        }
        public IActionResult WalletActivities()
        {
            return View(_model);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public  IActionResult PrintTest()
        {
          

           
                

                return View(_model);
            

            
        }

    }
}