using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
    public class ScheduleValidator : BaseValidator<Schedule>
    {
        public ScheduleValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.UserId).Must(id => BeAValidUser(id));
            RuleFor(x => x.WeekName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.StartTime.ToString("HH:mm")).NotEmpty().Matches(@"^([01]\d|2[0-3]):([0-5]\d)$");
            RuleFor(x => x.EndTime.ToString("HH:mm")).NotEmpty().Matches(@"^([01]\d|2[0-3]):([0-5]\d)$");
        } 
    }
}

