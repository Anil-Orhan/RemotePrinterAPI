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
    public class OptionService:IOptionService
    {
        private IOperationService _operationService;
        private IOptionDal _optionDal;

        public OptionService(IOptionDal optionDal,IOperationService operationService)
        {
            _optionDal = optionDal;
            _operationService = operationService;
        }
        public bool Add(Option entity)
        {

           _optionDal.Add(entity);

           return true;
        }

        public void Delete(Option entity)
        {
            _optionDal.Delete(entity);
        }

        public void Update(Option entity)
        {
            _optionDal.Update(entity);
        }

        public List<Option> GetAll()
        {
           return _optionDal.GetAll();
        }

        public Option GetById(Guid Id)
        {
           return _optionDal.Get(p=>p.Id==Id);
        }
    }
}
