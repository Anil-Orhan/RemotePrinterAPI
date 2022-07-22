using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfFileDal:EfEntityRepositoryBase<EntityLayer.Concrete.File, DataContext>, IFileDal
    {


    }
}
