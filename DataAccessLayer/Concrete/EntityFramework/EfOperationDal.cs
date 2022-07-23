using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfOperationDal : EfEntityRepositoryBase<EntityLayer.Concrete.Operation, DataContext>, IOperationDal
{


}