using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface IPurchaseService : IServiceRepository<Purchase>
    {
        IDataResult<List<PurchaseDetailsDto>> GetPurchaseDetails();
        IDataResult<PurchaseDetailsDto> GetPurchaseDetailById(int id);
        IDataResult<List<PurchaseDetailsDto>> GetPurchaseDetailsByUserId(int id);
    }
}
