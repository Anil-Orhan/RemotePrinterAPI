using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete;

public class WalletActivityService:IWalletActivityService
{
    private IWalletActivityDal _walletActivityDal;
    public WalletActivityService(IWalletActivityDal walletActivityDal)
    {
            _walletActivityDal=walletActivityDal;
    }
    public bool Add(WalletActivity entity)
    {
        _walletActivityDal.Add(entity);
        return true;
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
}