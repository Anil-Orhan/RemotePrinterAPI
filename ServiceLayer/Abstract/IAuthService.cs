﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstract
{
    public interface IAuthService
    {

        bool Login(string username,string password);
    }
}
