using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(currency => currency.CurrencyName).NotEmpty();
            RuleFor(currency => currency.CurrencyName).MinimumLength(3);
        }
    }
}
