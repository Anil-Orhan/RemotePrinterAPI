using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfWalletDal : EfEntityRepositoryBase<Wallet, DataContext>, IWalletDal
{


}