using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceLayer.Abstract;
using WebTestPanelMVC.Models;

namespace WebTestPanelMVC.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IPrinterService _printerService;
        private IPrintModelService _printModelService;
        private IFileService _fileService;
        private IReportService _reportService;
        private AllListModel _model;
        
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger, IUserService userService, IPrinterService printerService, IPrintModelService printModelService, IFileService fileService, IReportService reportService)
        {
            _logger = logger;
            _userService = userService;
            _printerService = printerService;
            _printModelService = printModelService;
            _fileService = fileService;
            _reportService = reportService;
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
        public IActionResult Tables()
        {
            return View(_model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}