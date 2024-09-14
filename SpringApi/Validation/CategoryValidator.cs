using FluentValidation;
using SpringApi.Model;
using SpringApi.Data;

namespace SpringApi.Validation
{
    public class CategoryValidator : BaseValidator<Category>
    {
        public CategoryValidator(ApplicationDbContext db) : base(db)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryImage)
                .NotNull().Must(pic => ValidImage(pic))
                .WithMessage("Profile picture must be a valid image: Png, Jpeg, or Jpg image file.")
                .Must(file => file.Length <= 5 * 1024 * 1024);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}



