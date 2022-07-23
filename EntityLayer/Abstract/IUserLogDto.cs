using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IUserLogDto:IDto,IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public Guid PrinterId { get; set; }
        public string PrinterName { get; set; }
        public DateTime PrintDate { get; set; }
        public Guid FileId { get; set; }
    }
}
