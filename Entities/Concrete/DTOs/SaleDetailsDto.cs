using Core.Entities;
using System;

namespace Entities.Concrete.DTOs
{
    public class SaleDetailsDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CoinName { get; set; }
        public string CurrencyName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SaleUnitPrice { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime TradingDate { get; set; }
    }
}
