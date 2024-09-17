using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
    public class BookingValidator : BaseValidator<Booking>
    {
        public BookingValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.UserId).Must(id => BeAValidUser(id));
            RuleFor(x => x.BookingDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(x => x.BookingDate);
            RuleFor(x => x.Duration).GreaterThan(0);
            RuleFor(x => x.PaymentType).IsInEnum();
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Charge).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Message).MaximumLength(500);
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        }
    } 
} 

