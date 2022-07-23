using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IFile:IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FileUrl { get; set; }
        public string CloudUrl { get; set; }
        public Guid OperationId { get; set; }

    }
}
