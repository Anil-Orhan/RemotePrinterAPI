using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPrintModelDal : EfEntityRepositoryBase<PrintModel, DataContext>, IPrintModelDal
    {


    }
}
