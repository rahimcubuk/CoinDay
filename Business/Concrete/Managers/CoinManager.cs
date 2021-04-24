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
    public class CoinManager : ICoinService
    {
        #region Kurucu Metot
        private ICoinDal _coinDal;
        public CoinManager(ICoinDal coinDal)
        {
            _coinDal = coinDal;
        }
        #endregion

        #region Business Kurallari

        #endregion

        #region Metotlar

        [ValidationAspect(typeof(CoinValidator))]
        [SecuredOperation("admin,workable.coin")]
        [CacheRemoveAspect("CoinManager.Get")]
        public IResult Add(Coin entity)
        {
            _coinDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("CoinManager.Get")]
        [SecuredOperation("admin,workable.coin")]
        public IResult Delete(Coin entity)
        {
            _coinDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Coin>> GetAll()
        {
            var data = _coinDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Coin>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Coin>>(data, Messages.SuccessListed);
        }

        public IDataResult<Coin> GetById(int id)
        {
            var data = _coinDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Coin>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Coin>(data, Messages.SuccessListed);
        }

        [CacheRemoveAspect("CoinManager.Get")]
        [SecuredOperation("admin,workable.coin")]
        public IResult Update(Coin entity)
        {
            _coinDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
