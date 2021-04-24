using Core.Entities;

namespace Entities.Concrete.Models
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
    }
}
