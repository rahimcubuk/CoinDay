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
    public class EfSaleDal : EntityRepository<Sale, CoindayDBContext>, ISaleDal
    {
        public List<SaleDetailsDto> GetSaleDetails(Expression<Func<SaleDetailsDto, bool>> filter = null)
        {
            using (var context = new CoindayDBContext())
            {
                #region Create Data
                IQueryable<SaleDetailsDto> data = CreateData(context);
                #endregion
                return (filter == null ? data.ToList() :
                                        data.Where(filter).ToList());
            }
        }

        public SaleDetailsDto GetSaleDetailsById(Expression<Func<SaleDetailsDto, bool>> filter)
        {
            using (var context = new CoindayDBContext())
            {
                #region Create Data
                IQueryable<SaleDetailsDto> data = CreateData(context);
                #endregion
                return data.FirstOrDefault(filter);
            }
        }

        private IQueryable<SaleDetailsDto> CreateData(CoindayDBContext context)
        {
            return from sl in context.Sales
                   join us in context.Users on sl.UserId equals us.UserId
                   join co in context.Coins on sl.CoinId equals co.Id
                   join cu in context.Currencies on sl.CurrencyId equals cu.Id
                   select new SaleDetailsDto
                   {
                       Id = sl.Id,
                       UserId = us.UserId,
                       CoinName = co.CoinName,
                       CurrencyName = cu.CurrencyName,
                       Quantity = sl.Quantity,
                       UnitPrice = sl.UnitPrice,
                       SaleUnitPrice = sl.SaleUnitPrice,
                       ExchangeRate = sl.ExchangeRate,
                       TradingDate = sl.TradingDate
                   };
        }
    }
}