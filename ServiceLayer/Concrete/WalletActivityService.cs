using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete;

public class WalletActivityService:IWalletActivityService
{
    private IWalletActivityDal _walletActivityDal;
  
    private IWalletService _walletService;
    public WalletActivityService(IWalletActivityDal walletActivityDal, IWalletService walletService)
    {
        _walletActivityDal = walletActivityDal;
       
        _walletService = walletService;
    }
    public bool Add(WalletActivity entity)
    {
        //var userCheck=UserCheck(entity.UserId);
     
          var wallet=  _walletService.GetAll().SingleOrDefault(p => p.UserId == entity.UserId);
             if (wallet !=null)
             {
              _walletActivityDal.Add(entity);
                return true;
              }
          else
          {
              return false;
          }
        
      

       
    }

    public void Delete(WalletActivity entity)
    {
        _walletActivityDal.Delete(entity);
    }

    public void Update(WalletActivity entity)
    {
        _walletActivityDal.Update(entity);
    }

    public List<WalletActivity> GetAll()
    {
        return _walletActivityDal.GetAll();
    }

    public WalletActivity GetById(Guid Id)
    {
      return  _walletActivityDal.Get(p=>p.Id==Id);
    }

    //public bool UserCheck(Guid userId)
    //{

    //    var check = _userService.GetById(userId);
    //    if (check == null)
    //    {
    //        return false;
    //    }

    //    else
    //    {
    //        return true;
    //    }

    //}
}