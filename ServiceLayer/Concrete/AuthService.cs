using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class AuthService:IAuthService
    {
        private IUserService _userService;
        private User activeUser;
        public AuthService(IUserService userService)
        {
            _userService = userService;
        }
        public bool Login(string username, string password)
        {
            var result = _userService.GetByUserName(username);
            if (result.password==password)
            {
                return true;
                this.activeUser = result;
            }
            else
            {
                return false;
            }
        }

        public Guid GetActiveUserId()
        {
            //return activeUser.id;
            return new Guid("3fa85f64-5717-4562-b3fc-2c963f66afc6");
        }
    }
}
