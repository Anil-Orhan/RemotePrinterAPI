﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class File:IFile,IEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FileUrl { get; set; }
        public string CloudUrl { get; set; }

    }

}
