﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IStorageSevice
    {

        void Upload(IFormFile formFile);

    }
}
