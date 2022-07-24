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
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public  double FileSize { get; set; }
        public DateTime CreateDate { get; set; }
        public int PageNumber { get; set; }
        public string FileUrl { get; set; }
        public string CloudUrl { get; set; }
        public Guid OperationId { get; set; }

    }
}
