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
            RuleFor(x => x.Image)
                .NotEmpty()
                .Must(file => file.Length <= 10 * 1024 * 1024) 
                .WithMessage("Image must be less than 10 MB.");
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}



