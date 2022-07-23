using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class Option:IOption,IEntity
{
    public Guid Id { get; set; }
    public short Colored { get; set; }
    public short Colorless { get; set; }
    public double Amount { get; set; }
}