using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IOption
    {

        public Guid Id { get; set; }
        public short Colored { get; set; }
        public short Colorless { get; set; }
        public double Amount { get; set; }
        public int PageNumber { get; set; }




    }
}
