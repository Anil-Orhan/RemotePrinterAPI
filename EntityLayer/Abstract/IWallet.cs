namespace EntityLayer.Abstract;

public interface IWallet
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double Balance { get; set; }

}