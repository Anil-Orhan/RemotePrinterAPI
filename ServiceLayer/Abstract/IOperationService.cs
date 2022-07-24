using EntityLayer.Concrete;
using File = System.IO.File;

namespace ServiceLayer.Abstract;

public interface IOperationService : IBusinessService<EntityLayer.Concrete.Operation>
{
    public bool CreateIndexOperation(Operation entity, List<EntityLayer.Concrete.File> files, User user,
        Printer printer);

}