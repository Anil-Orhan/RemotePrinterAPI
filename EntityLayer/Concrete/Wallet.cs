using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Wallet:IWallet,IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
    }
}
