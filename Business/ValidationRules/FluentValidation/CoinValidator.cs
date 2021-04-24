using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CoinValidator : AbstractValidator<Coin>
    {
        public CoinValidator()
        {
            RuleFor(coin => coin.CoinName).NotEmpty();
            RuleFor(coin => coin.CoinName).MinimumLength(3);
        }
    }
}
