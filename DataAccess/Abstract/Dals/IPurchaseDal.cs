using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface IPurchaseDal : IEntityRepository<Purchase>
    {
        List<PurchaseDetailsDto> GetPurchaseDetails(Expression<Func<PurchaseDetailsDto, bool>> filter = null);
        PurchaseDetailsDto GetPurchaseDetailsById(Expression<Func<PurchaseDetailsDto, bool>> filter);
    }
}