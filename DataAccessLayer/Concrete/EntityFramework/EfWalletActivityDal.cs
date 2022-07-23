using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfWalletActivityDal : EfEntityRepositoryBase<EntityLayer.Concrete.WalletActivity, DataContext>, IWalletActivityDal
{


}