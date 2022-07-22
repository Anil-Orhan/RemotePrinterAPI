namespace EntityLayer.Abstract;

public interface IPrinter
{

    public Guid Id { get; set; }
    public string PrinterIP { get; set; }
    public string PrinterName { get; set; }
    public string
        Coordinate
    { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}