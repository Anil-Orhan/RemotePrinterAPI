using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PrintModel:IPrintModel,IEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PrinterId { get; set; }

        public Guid FileId { get; set; }
        public DateTime Date { get; set; }

    }
}
