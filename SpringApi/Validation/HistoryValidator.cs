using FluentValidation;
using SpringApi.Model;
using SpringApi.Data;

namespace SpringApi.Validation
{
    public class HistoryValidator : BaseValidator<History>
    {
        public HistoryValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.UserId).Must(id => BeAValidUser(id));
            RuleFor(x => x.ServiceId).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Currency).NotEmpty().MaximumLength(3);
            RuleFor(x => x.Charge).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Commission).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Details).MaximumLength(1000);
            RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
        }
    }
}
