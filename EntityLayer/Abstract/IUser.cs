using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IUser
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public Guid WalletId { get; set; }

    }
}
