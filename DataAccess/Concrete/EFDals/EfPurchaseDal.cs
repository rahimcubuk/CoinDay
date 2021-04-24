using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EFDals
{
    public class EfPurchaseDal : EntityRepository<Purchase, CoindayDBContext>, IPurchaseDal
    {
        public List<PurchaseDetailsDto> GetPurchaseDetails(Expression<Func<PurchaseDetailsDto, bool>> filter = null)
        {
            using (var context = new CoindayDBContext())
            {
                #region Create Data
                IQueryable<PurchaseDetailsDto> data = CreateData(context);
                #endregion
                return (filter == null ? data.ToList() :
                                        data.Where(filter).ToList());
            }
        }

        public PurchaseDetailsDto GetPurchaseDetailsById(Expression<Func<PurchaseDetailsDto, bool>> filter)
        {
            using (var context = new CoindayDBContext())
            {
                #region Create Data
                IQueryable<PurchaseDetailsDto> data = CreateData(context);
                #endregion
                return data.FirstOrDefault(filter);
            }
        }
        private IQueryable<PurchaseDetailsDto> CreateData(CoindayDBContext context)
        {
            return from pu in context.Purchases
                   join us in context.Users on pu.UserId equals us.UserId
                   join co in context.Coins on pu.CoinId equals co.Id
                   join cu in context.Currencies on pu.CurrencyId equals cu.Id
                   select new PurchaseDetailsDto
                   {
                       Id = pu.Id,
                       UserId = us.UserId,
                       CoinName = co.CoinName,
                       CurrencyName = cu.CurrencyName,
                       Quantity = pu.Quantity,
                       UnitPrice = pu.UnitPrice,
                       ExchangeRate = pu.ExchangeRate,
                       TradingDate = pu.TradingDate
                   };
        }
    }
}