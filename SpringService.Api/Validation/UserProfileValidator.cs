using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
  public class UserProfileValidator : BaseValidator<UserProfile>
  {
    public UserProfileValidator(ApplicationDbContext db) : base(db)
    {
        RuleFor(x => x.Slug).NotEmpty().MaximumLength(100);
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ProfilePicture).NotNull().Must(pic => ValidImage(pic)).WithMessage("Profile picture must be a valid image: png, jpeg, or jpg image file.").Must(file => file.Length <= 5 * 1024 * 1024);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Matches(@"[A-Z]").Matches(@"[a-z]").Matches(@"[0-9]").Matches(@"\W").WithMessage(
            """
            Password Must contain 8 or more characters
            Password Must contain at least 1 uppercase character
            Password Must contain at least 1 lowercase character
            Password Must contain at least 1 number
            Password Must contain at least 1 special Character
            """);
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords must match");
        RuleFor(x => x.Balance).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Social).NotEmpty().Must(x => x.Length <= 10).WithMessage("Maximum 10 social links allowed.");
        RuleForEach(x => x.Social).NotEmpty().MaximumLength(100);
        RuleFor(x => x.IsVerified).NotNull();
        RuleFor(x => x.Designation).MaximumLength(50);
        RuleFor(x => x.Details).MaximumLength(1000);
        RuleFor(x => x.Experience).MaximumLength(500);
        RuleFor(x => x.Qualification).MaximumLength(200);
    }
  }
}


