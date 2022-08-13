using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ServiceLayer.Abstract;
using File = EntityLayer.Concrete.File;

namespace ServiceLayer.Concrete;

public class OperationService:IOperationService
{
    private IOperationDal _operationDal;
    private IWalletActivityService _walletActivityService;
    private IPrintModelService _printModelService;
    public OperationService(IOperationDal operationDal, IWalletActivityService walletActivityService, IPrintModelService printModelService)
    {
        _operationDal = operationDal;
        _walletActivityService = walletActivityService;
        _printModelService = printModelService;
    }
    public bool Add(Operation entity)
    {

        _operationDal.Add(entity);
        return true;
    }

    public void Delete(Operation entity)
    {
        _operationDal.Delete(entity);
    }

    public void Update(Operation entity)
    {
        _operationDal.Update(entity);
    }

    public List<Operation> GetAll()
    {
     return   _operationDal.GetAll();
    }

    public Operation GetById(Guid Id)
    {
       return _operationDal.Get(p=>p.Id==Id);
    }

    public bool CreateIndexOperation(Operation entity,List<File> files, User user, Printer printer)
    {
        WalletActivity walletActivity = new WalletActivity { UserId = entity.UserId, Amount = entity.TotalAmount, ActivityDate =DateTime.Now,OperationType = "Deposit",NewBalance = 0,PreviousBalance = 0};
        var walletResult = _walletActivityService.Add(walletActivity);
        if (walletResult)

        {
            CreatePrintModel(files, user, printer);
            _operationDal.Add(entity);
            return true;
        }
        else
        {

            return false;
        }
    }
    public void CreatePrintModel(List<File> files, User user, Printer printer)
    {


        foreach (var file in files)
        {
            PrintModel printModel = new PrintModel { UserId = user.id, Date = DateTime.Now, PrinterId = printer.Id, FileId = file.Id };
            _printModelService.Add(printModel);


        }
    }

    public double TotalExpense(Guid id)
    {
      var operationList=  _operationDal.GetAll(p => p.UserId == id);

       var result= operationList.Sum(p=>p.TotalAmount);
        return result;
    }

    public int TotalProcessWithDate(Guid id,int day)
    {
        if(day == 0 || day == null) { day = 1000; }

        var operationList = _operationDal.GetAll(p => p.UserId == id&&p.OperationTime>=DateTime.Now.AddDays(-day));

        var result = operationList.Count;
        return result;
    }
}