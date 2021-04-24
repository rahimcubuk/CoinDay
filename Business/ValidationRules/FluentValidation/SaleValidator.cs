using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.UserId).NotEmpty();
            RuleFor(sale => sale.CoinId).NotEmpty();
            RuleFor(sale => sale.CurrencyId).NotEmpty();
            RuleFor(sale => sale.Quantity).NotEmpty();
            RuleFor(sale => sale.UnitPrice).NotEmpty();
            RuleFor(sale => sale.SaleUnitPrice).NotEmpty();
            RuleFor(sale => sale.ExchangeRate).NotEmpty();

            RuleFor(sale => sale.Quantity).GreaterThan(0);
            RuleFor(sale => sale.UnitPrice).GreaterThan(0);
            RuleFor(sale => sale.SaleUnitPrice).GreaterThan(0);
            RuleFor(sale => sale.ExchangeRate).GreaterThan(0);
        }
    }
}
