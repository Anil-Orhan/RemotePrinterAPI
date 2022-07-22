using EntityLayer.Concrete;

namespace ServiceLayer.Abstract;

public interface IUserService : IBusinessService<User>
{

    User GetByUserName(string userName);
}
