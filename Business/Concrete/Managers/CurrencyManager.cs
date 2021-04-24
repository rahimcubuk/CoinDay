using Business.Abstract.Services;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class CurrencyManager : ICurrencyService
    {
        #region Kurucu Metot
        private ICurrencyDal _currencyDal;
        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }
        #endregion

        #region Business Kurallari

        #endregion

        #region Metotlar

        [ValidationAspect(typeof(CurrencyValidator))]
        [CacheRemoveAspect("CurrencyManager.Get")]
        [SecuredOperation("admin,workable.currency")]
        public IResult Add(Currency entity)
        {
            _currencyDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("CurrencyManager.Get")]
        [SecuredOperation("admin,workable.currency")]
        public IResult Delete(Currency entity)
        {
            _currencyDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Currency>> GetAll()
        {
            var data = _currencyDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Currency>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Currency>>(data, Messages.SuccessListed);
        }

        public IDataResult<Currency> GetById(int id)
        {
            var data = _currencyDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Currency>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Currency>(data, Messages.SuccessListed);
        }

        [CacheRemoveAspect("CurrencyManager.Get")]
        [SecuredOperation("admin,workable.currency")]
        public IResult Update(Currency entity)
        {
            _currencyDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
