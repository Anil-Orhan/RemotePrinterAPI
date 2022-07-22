using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;

namespace ServiceLayer.Abstract;

public interface IReportService:IDto
{

    //public UserLogDto UserLogCreate(PrintModel printModel);
    public void CreateUserLog(PrintModel printModel);
}