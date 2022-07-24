using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;
using File = EntityLayer.Concrete.File;

namespace ServiceLayer.Concrete
{
    public class OptionService:IOptionService
    {
       
        private IOptionDal _optionDal;
        private IOperationService _operationService;
        private IFileService _fileService;
        private IWalletActivityService _walletActivityService;
        private IPrintModelService _printModelService;


        public OptionService(IOptionDal optionDal,IOperationService operationService, IFileService fileService, IWalletActivityService walletActivityService,IPrintModelService printModelService)
        {
            _optionDal = optionDal;
            _operationService = operationService;
            _fileService = fileService;
            _walletActivityService = walletActivityService;
            _printModelService= printModelService;
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

   

        public bool AddOptionForOperation(Option entity, User user,List<File> files,Printer printer)
        {
          
            fileSave(files);
           entity= PreparationForOperations(entity);
           _optionDal.Add(entity);
        
        
           
           Operation operation = new Operation {OptionId = entity.Id,OperationTime = DateTime.Now,UserId = user.id,
               TotalAmount = entity.Amount, OperationResult = true };
           _operationService.CreateIndexOperation(operation,files, user, printer);
           
            return true;
        }

     
      
      
      
      public Option PreparationForOperations(Option options)
        {

            var coloredPapersAmounth = options.Colored * 5*1.18;
            var colorlessPapersAmounth = options.Colorless * 2 * 1.18;
            options.Amount=coloredPapersAmounth+colorlessPapersAmounth;

            return options;

        }
        public void fileSave(List<File> files)
        {
            foreach (var file in files)
            {
                _fileService.Add(file);
            }
        }
    }
}
