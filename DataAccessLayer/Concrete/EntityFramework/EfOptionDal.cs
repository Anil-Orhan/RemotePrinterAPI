using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfOptionDal : EfEntityRepositoryBase<EntityLayer.Concrete.Option, DataContext>, IOptionDal
{


}