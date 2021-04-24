using Business.Abstract.Repository;
using Entities.Concrete.Models;

namespace Business.Abstract.Services
{
    public interface ICoinService : IServiceRepository<Coin>
    {
    }
}
