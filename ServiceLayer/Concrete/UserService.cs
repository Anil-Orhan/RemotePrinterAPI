using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class UserService:IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
                _userDal=userDal;
        }     
        public bool Add(User entity)
        {
            _userDal.Add(entity);
            return true;
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
            
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
          
        }

        public List<User> GetAll()
        {
           return _userDal.GetAll();
        }

        public User GetById(Guid Id)
        {
           return _userDal.Get(p=>p.id.Equals(Id));
        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(p => p.userName == userName);
        }
    }
}
