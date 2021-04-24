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
    public class PurchaseManager : IPurchaseService
    {
        #region Kurucu Metot
        private IPurchaseDal _purchaseDal;
        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }
        #endregion

        #region Business Kurallari

        #endregion

        #region Metotlar

        [ValidationAspect(typeof(SaleValidator))]
        [CacheRemoveAspect("PurchaseManager.Get")]
        [SecuredOperation("admin,workable.purchase,user")]
        public IResult Add(Purchase entity)
        {
            _purchaseDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("PurchaseManager.Get")]
        [SecuredOperation("admin,workable.purchase,user")]
        public IResult Delete(Purchase entity)
        {
            _purchaseDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Purchase>> GetAll()
        {
            var data = _purchaseDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Purchase>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Purchase>>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.purchase,user")]
        public IDataResult<Purchase> GetById(int id)
        {
            var data = _purchaseDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Purchase>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Purchase>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.purchase,user")]
        public IDataResult<PurchaseDetailsDto> GetPurchaseDetailById(int id)
        {
            var data = _purchaseDal.GetPurchaseDetailsById(x => x.Id == id);
            if (data == null) return new ErrorDataResult<PurchaseDetailsDto>(data, Messages.NotFound);
            return new SuccessDataResult<PurchaseDetailsDto>(data, Messages.SuccessListed);
        }

        public IDataResult<List<PurchaseDetailsDto>> GetPurchaseDetails()
        {
            var data = _purchaseDal.GetPurchaseDetails();
            if (data == null) return new ErrorDataResult<List<PurchaseDetailsDto>>(data, Messages.NotFound);
            return new SuccessDataResult<List<PurchaseDetailsDto>>(data, Messages.SuccessListed);
        }

        [SecuredOperation("admin,workable.purchase,user")]
        public IDataResult<List<PurchaseDetailsDto>> GetPurchaseDetailsByUserId(int id)
        {
            var data = _purchaseDal.GetPurchaseDetails(x => x.UserId == id);
            if (data == null) return new ErrorDataResult<List<PurchaseDetailsDto>>(data, Messages.NotFound);
            return new SuccessDataResult<List<PurchaseDetailsDto>>(data, Messages.SuccessListed);
        }

        [CacheRemoveAspect("PurchaseManager.Get")]
        [SecuredOperation("admin,workable.purchase,user")]
        public IResult Update(Purchase entity)
        {
            _purchaseDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
