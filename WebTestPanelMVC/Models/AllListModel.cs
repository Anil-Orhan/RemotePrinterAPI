using EntityLayer.Concrete;
using EntityLayer.DTO;
using File = EntityLayer.Concrete.File;

namespace WebTestPanelMVC.Models
{
    public class AllListModel
    {
        public List<UserLogDto> UserLogs { get; set; }
        public List<Printer> Printers { get; set; }
        public List<User> Users { get; set; }
        public List<PrintModel> PrintModels { get; set; }
        public List<File> Files { get; set; }

    }
}
    

