using DataAccessLayer.Abstract;
using EntityLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfFileDal:EfEntityRepositoryBase<EntityLayer.Concrete.File, DataContext>, IFileDal
    {


    }
}
