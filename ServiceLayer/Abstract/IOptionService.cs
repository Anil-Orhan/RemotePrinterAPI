using EntityLayer.Concrete;
using File = EntityLayer.Concrete.File;

namespace ServiceLayer.Abstract;

public interface IOptionService : IBusinessService<EntityLayer.Concrete.Option>
{

    public bool AddOptionForOperation(Option entity,User user,List<File> files, Printer printer);
}