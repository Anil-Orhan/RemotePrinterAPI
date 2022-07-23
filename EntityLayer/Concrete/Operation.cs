using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Operation:IOperation,IEntity
    {
        public Guid Id { get; set; }
        public Guid PrintModelId { get; set; }
        public Guid UserId { get; set; }
        public Guid OptionId { get; set; }
        public double TotalAmount { get; set; }
        public bool OperationResult { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
