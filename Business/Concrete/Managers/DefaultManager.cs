using Business.Abstract.Services;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class DefaultManager : IDefaultService
    {
        #region Kurucu Metot
        private IDefaultDal _defaultDal;
        public DefaultManager(IDefaultDal defaultDal)
        {
            _defaultDal = defaultDal;
        }
        #endregion

        #region Business Kurallari

        private IResult CheckIfUserExists(int id)
        {
            var result = _defaultDal.Get(x => x.UserId == id);
            return result == null ? new ErrorResult(Messages.UserNotFound) : (IResult)new SuccessResult();
        }

        #endregion

        #region Metotlar

        [ValidationAspect(typeof(DefaultValidator))] //--> Core katmaninda CCC altinda validation tool a yonlendirilir. 
        [SecuredOperation("admin,add.something")] //-> Auth islemi
        [CacheRemoveAspect("DefaultManager.Get")] //-> ekleme işlemi sonrası cache'e kaydedilen veriyi temizler. Delete ve update için de kullanılır.
        public IResult Add(Default entity)
        {
            var result = BusinessRules.Run(CheckIfUserExists(1)); //--> BusinessRules uygulanmasi
            if (!(result is null)) return result;

            _defaultDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Default entity)
        {
            _defaultDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect(duration: 10)] //-> 10 Dk boyunca çekilen verilen bellekte tutulur.
        public IDataResult<List<Default>> GetAll()
        {
            var data = _defaultDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Default>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Default>>(data, Messages.SuccessListed);
        }

        public IDataResult<Default> GetById(int id)
        {
            var data = _defaultDal.Get(x => x.UserId == id);
            if (data == null)
            {
                return new ErrorDataResult<Default>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Default>(data, Messages.SuccessListed);
        }

        public IResult Update(Default entity)
        {
            _defaultDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
