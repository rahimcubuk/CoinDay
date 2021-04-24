using Core.Entities;
using System;

namespace Entities.Concrete.Models
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoinId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime TradingDate { get; set; }
    }
}
