using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
    public class ReviewValidator : BaseValidator<Review>
    {
        public ReviewValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.ServiceCategory).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ServiceUserId).Must(id => BeAValidUser(id));
            RuleFor(x => x.ServiceProviderId).Must(id => BeAValidUser(id));
            RuleFor(x => x.Time).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Star).InclusiveBetween(0, 5);
        }
    }

}
