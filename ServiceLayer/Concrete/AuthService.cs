using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class AuthService:IAuthService
    {
        private IUserService _userService;
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
            }
            else
            {
                return false;
            }
        }
    }
}
