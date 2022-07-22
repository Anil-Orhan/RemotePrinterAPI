using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.DTO;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfUserLogDal : EfEntityRepositoryBase<UserLogDto, DataContext>, IUserLogDal
{



  
}