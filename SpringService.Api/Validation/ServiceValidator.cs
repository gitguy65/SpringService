using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
    public class ServiceValidator : BaseValidator<Service>
    {
        public ServiceValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
