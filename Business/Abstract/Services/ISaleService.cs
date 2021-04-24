using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface ISaleService : IServiceRepository<Sale>
    {
        IDataResult<List<SaleDetailsDto>> GetSaleDetails();
        IDataResult<SaleDetailsDto> GetSaleDetailById(int id);
        IDataResult<List<SaleDetailsDto>> GetSaleDetailsByUserId(int id);
    }
}
