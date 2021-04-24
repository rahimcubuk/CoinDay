using Core.Entities;

namespace Entities.Concrete.Models
{
    public class Coin : IEntity
    {
        public int Id { get; set; }
        public string CoinName { get; set; }
    }
}
