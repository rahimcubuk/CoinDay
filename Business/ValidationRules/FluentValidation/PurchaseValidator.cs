using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PurchaseValidator : AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(purchase => purchase.UserId).NotEmpty();
            RuleFor(purchase => purchase.CoinId).NotEmpty();
            RuleFor(purchase => purchase.CurrencyId).NotEmpty();
            RuleFor(purchase => purchase.Quantity).NotEmpty();
            RuleFor(purchase => purchase.UnitPrice).NotEmpty();
            RuleFor(purchase => purchase.ExchangeRate).NotEmpty();

            RuleFor(purchase => purchase.Quantity).GreaterThan(0);
            RuleFor(purchase => purchase.UnitPrice).GreaterThan(0);
            RuleFor(purchase => purchase.ExchangeRate).GreaterThan(0);
        }
    }
}
