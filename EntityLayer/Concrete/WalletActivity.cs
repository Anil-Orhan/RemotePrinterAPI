using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class WalletActivity:IWalletActivity,IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime ActivityDate { get; set; }
    public string OperationType { get; set; }
    public double Amount { get; set; }
    public double PreviousBalance { get; set; }
    public double NewBalance { get; set; }
}