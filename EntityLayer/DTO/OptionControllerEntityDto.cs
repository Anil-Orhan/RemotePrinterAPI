using EntityLayer.Abstract;
using EntityLayer.Concrete;
using File = EntityLayer.Concrete.File;

namespace EntityLayer.DTO;

public class OptionControllerEntityDto : IEntity, IDto
{
    public List<File> Files { get; set; }
    public Printer Printer { get; set; }
    public Option Option { get; set; }
    public User User { get; set; }



}