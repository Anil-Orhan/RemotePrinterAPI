using DataAccessLayer.Abstract;
using ServiceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ServiceLayer.Concrete
{
    public class FileService : IFileService
    {
        IFileDal _fileDal;

        public FileService(IFileDal fileDal)
        {
            _fileDal=fileDal;
        }

        public bool Add(EntityLayer.Concrete.File entity)
        {
            _fileDal.Add(entity);
            return true;
        }

        public void Delete(EntityLayer.Concrete.File entity)
        {
            _fileDal.Delete(entity);
        }

        public List<EntityLayer.Concrete.File> GetAll()
        {
           return _fileDal.GetAll();
        }

        public EntityLayer.Concrete.File GetById(Guid Id)
        {
           return _fileDal.Get(p=>p.Id.Equals(Id));
        }

        public void Update(EntityLayer.Concrete.File entity)
        {
            _fileDal.Update(entity);
        }

        public string TakeFileExtension(EntityLayer.Concrete.File file)
        {
           

            return "";
        }
    }

}
