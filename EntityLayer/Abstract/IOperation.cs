namespace EntityLayer.Abstract;

public interface IOperation
{
    public Guid Id { get; set; }
   
    public Guid UserId { get; set; }
    public Guid OptionId { get; set; }
    public double TotalAmount { get; set; }
    public bool OperationResult { get; set; }
    public DateTime OperationTime { get; set; }
}