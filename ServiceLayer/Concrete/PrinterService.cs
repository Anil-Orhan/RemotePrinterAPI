using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete
{
    public class PrinterService:IPrinterService
    {
        private IPrinterDal _printerDal;

        public PrinterService(IPrinterDal printerDal)
        {
                _printerDal=printerDal;
        }
        public bool Add(Printer entity)
        {
            _printerDal.Add(entity);
            return true;
        }

        public void Delete(Printer entity)
        {
            _printerDal.Delete(entity);
        }

        public void Update(Printer entity)
        {
            _printerDal.Update(entity);
        }

        public List<Printer> GetAll()
        {
           return _printerDal.GetAll();
        }

        public Printer GetById(Guid Id)
        {
           return _printerDal.Get(p => p.Id == Id);
        }
    }
}
