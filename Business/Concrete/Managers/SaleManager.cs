using Business.Abstract.Services;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class SaleManager : ISaleService
    {
        #region Kurucu Metot
        private ISaleDal _saleDal;
        public SaleManager(ISaleDal coinDal)
        {
            _saleDal = coinDal;
        }
        #endregion

        #region Business Kurallari

        #endregion

        #region Metotlar

        [ValidationAspect(typeof(SaleValidator))]
        [CacheRemoveAspect("SaleManager.Get")]
        [SecuredOperation("admin,workable.sale,user")]
        public IResult Add(Sale entity)
        {
            _saleDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("SaleManager.Get")]
        [SecuredOperation("admin,workable.sale,user")]
        public IResult Delete(Sale entity)
        {
            _saleDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Sale>> GetAll()
        {
            var data = _saleDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Sale>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Sale>>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.sale,user")]
        public IDataResult<Sale> GetById(int id)
        {
            var data = _saleDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Sale>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Sale>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.sale,user")]
        public IDataResult<SaleDetailsDto> GetSaleDetailById(int id)
        {
            var data = _saleDal.GetSaleDetailsById(x => x.Id == id);
            if (data == null) return new ErrorDataResult<SaleDetailsDto>(data, Messages.NotFound);
            return new SuccessDataResult<SaleDetailsDto>(data, Messages.SuccessListed);
        }

        public IDataResult<List<SaleDetailsDto>> GetSaleDetails()
        {
            var data = _saleDal.GetSaleDetails();
            if (data == null) return new ErrorDataResult<List<SaleDetailsDto>>(data, Messages.NotFound);
            return new SuccessDataResult<List<SaleDetailsDto>>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.sale,user")]
        public IDataResult<List<SaleDetailsDto>> GetSaleDetailsByUserId(int id)
        {
            var data = _saleDal.GetSaleDetails(x => x.UserId == id);
            if (data == null) return new ErrorDataResult<List<SaleDetailsDto>>(data, Messages.NotFound);
            return new SuccessDataResult<List<SaleDetailsDto>>(data, Messages.SuccessListed);
        }

        [CacheRemoveAspect("SaleManager.Get")]
        [SecuredOperation("admin,workable.sale,user")]
        public IResult Update(Sale entity)
        {
            _saleDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
