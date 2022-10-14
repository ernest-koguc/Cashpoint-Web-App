using FluentValidation;

namespace CashpointWeb.Models.Validators
{
    public class MoneyWithdrawValidator : AbstractValidator<MoneyWithdraw>
    {
        
        public MoneyWithdrawValidator()
        {
            RuleFor(p => p.Value).Custom((value, context) =>
            {
                if (value <= 0)
                    context.AddFailure($"{nameof(MoneyWithdraw)}.Value", "Cannot withdraw money less or equal to zero");
            });
        }
    }
}
