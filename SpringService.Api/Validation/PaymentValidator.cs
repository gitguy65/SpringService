using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
    public class PaymentValidator : BaseValidator<Payment>
    {
        public PaymentValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.UserId).Must(id => BeAValidUser(id));
            RuleFor(x => x.ServiceId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Currency).NotEmpty().MaximumLength(3);
            RuleFor(x => x.Charge).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Commission).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Details).MaximumLength(1000);
            RuleFor(x => x.PaymentType).IsInEnum();
        }
    }
}



