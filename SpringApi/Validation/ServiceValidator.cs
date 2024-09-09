using FluentValidation;
using SpringApi.Model;
using SpringApi.Data;

namespace SpringApi.Validation
{
    public class ServiceValidator : BaseValidator<Service>
    {
        public ServiceValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
