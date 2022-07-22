using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class PrintModelService : IPrintModelService

    {

       private IPrintModelDal _printModelDal;
       //private IReportService _reportService;

        public PrintModelService(IPrintModelDal printModelDal/*, IReportService reportService*/)
        {
            _printModelDal = printModelDal;
            //_reportService = reportService;
        }

        public bool Add(PrintModel entity)
        {
            _printModelDal.Add(entity);
            //_reportService.UserLogCreate(entity);

            return true;
        }

        public void Delete(PrintModel entity)
        {
            _printModelDal.Delete(entity);
        }

        public List<PrintModel> GetAll()
        {
          return _printModelDal.GetAll();
        }

        public PrintModel GetById(Guid Id)
        {
            return _printModelDal.Get(p => p.Id.Equals(Id));
        }

        public void Update(PrintModel entity)
        {
            _printModelDal.Update(entity);
        }
    }

}
