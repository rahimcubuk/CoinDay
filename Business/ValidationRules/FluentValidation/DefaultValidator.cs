using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DefaultValidator : AbstractValidator<Default>
    {
        public DefaultValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
