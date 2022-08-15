using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class PrintModelService : IPrintModelService

    {

       private IPrintModelDal _printModelDal;
      
     

        public PrintModelService(IPrintModelDal printModelDal)
        {
            _printModelDal = printModelDal;
           
        }

        public bool Add(PrintModel entity)
        {
            _printModelDal.Add(entity);
           

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
