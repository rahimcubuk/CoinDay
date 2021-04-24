using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface ISaleDal : IEntityRepository<Sale>
    {
        List<SaleDetailsDto> GetSaleDetails(Expression<Func<SaleDetailsDto, bool>> filter = null);
        SaleDetailsDto GetSaleDetailsById(Expression<Func<SaleDetailsDto, bool>> filter);
    }
}