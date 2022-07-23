using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class WalletService:IWalletService
    {
        private IWalletDal _walletDal;

        public WalletService(IWalletDal walletDal)
        {
                _walletDal= walletDal;
        }
        public bool Add(Wallet entity)
        {
           _walletDal.Add(entity);
           return true;
        }

        public void Delete(Wallet entity)
        {
            _walletDal.Delete(entity);
        }

        public void Update(Wallet entity)
        {
            _walletDal.Update(entity);
        }

        public List<Wallet> GetAll()
        {
          return  _walletDal.GetAll();
        }

        public Wallet GetById(Guid Id)
        {
            return _walletDal.Get(p => p.Id == Id);
        }
    }
}
