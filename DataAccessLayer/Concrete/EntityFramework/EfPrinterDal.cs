using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfPrinterDal : EfEntityRepositoryBase<Printer, DataContext>, IPrinterDal
{


}