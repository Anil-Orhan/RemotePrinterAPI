﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ServiceLayer.Abstract;

namespace ServiceLayer.Concrete;

public class OperationService:IOperationService
{
    private IOperationDal _operationDal;
    private IOptionService _optionService;

    public OperationService(IOperationDal operationDal, IOptionService optionService)
    {
        _operationDal = operationDal;
        _optionService = optionService;
    }
    public bool Add(Operation entity)
    {
       _operationDal.Add(entity);
       return true;
    }

    public void Delete(Operation entity)
    {
        _operationDal.Delete(entity);
    }

    public void Update(Operation entity)
    {
        _operationDal.Update(entity);
    }

    public List<Operation> GetAll()
    {
     return   _operationDal.GetAll();
    }

    public Operation GetById(Guid Id)
    {
       return _operationDal.Get(p=>p.Id==Id);
    }
}