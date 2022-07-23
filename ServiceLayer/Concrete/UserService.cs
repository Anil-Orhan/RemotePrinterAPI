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
    public class UserService:IUserService
    {
        private IUserDal _userDal;
        private IWalletService _walletService;
        private IWalletActivityService _walletActivityService;
        public UserService(IUserDal userDal, IWalletService walletService, IWalletActivityService walletActivityService)
        {
            _userDal = userDal;
            _walletService = walletService;
            _walletActivityService = walletActivityService;
        }
        public bool Add(User entity)
        {
            _userDal.Add(entity);
            var walletId= CreateWallet(entity);
            entity.WalletId=walletId;
            _userDal.Update(entity);

            return true;
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
            
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
          
        }

        public List<User> GetAll()
        {
           return _userDal.GetAll();
        }

        public User GetById(Guid Id)
        {
           return _userDal.Get(p=>p.id.Equals(Id));
        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(p => p.userName == userName);
        }

        public Guid CreateWallet(User user)
        {
            Wallet wallet = new Wallet
            {
                UserId = user.id,
                Balance = 0
            };
            _walletService.Add(wallet);
            WalletActivity walletActivity = new WalletActivity {UserId = user.id,NewBalance = 0,PreviousBalance = 0,Amount = 0,OperationType = "Wallet Creating",ActivityDate = DateTime.Now};
            _walletActivityService.Add(walletActivity);
            return wallet.Id;

        }
    }
}
