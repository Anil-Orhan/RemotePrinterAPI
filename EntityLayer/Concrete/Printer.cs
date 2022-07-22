using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class Printer:IPrinter,IEntity
{
    public Guid Id { get; set; }
    public string PrinterIP { get; set; }
    public string PrinterName { get; set; }
    public string Coordinate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}