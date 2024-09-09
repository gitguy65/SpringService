using FluentValidation;
using SpringApi.Model;

namespace SpringApi.Validation
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ProfilePicture)
                .NotNull()
                .Must(BeAValidImageFile)
                .WithMessage("Profile picture must be a valid PNG, JPEG, or JPG image file.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"[A-Z]")
                .Matches(@"[a-z]")
                .Matches(@"[0-9]")
                .Matches(@"\W")
                .WithMessage(
                """
                Password must be equal to or more than 8 characters
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
        private bool BeAValidImageFile(IFormFile file)
        {
            if (file == null)
                return false;

            var allowedExtensions = new[] { ".png", ".jpeg", ".jpg" };
            var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();

            return allowedExtensions.Contains(fileExtension);
        }
    }
}


