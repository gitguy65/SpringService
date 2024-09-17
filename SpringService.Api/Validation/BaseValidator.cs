using FluentValidation;
using SpringService.Api.Models;
using SpringService.Api.Data;

namespace SpringService.Api.Validation
{
  public class BaseValidator<T> : AbstractValidator<T>
  {
    private readonly ApplicationDbContext db;
    public BaseValidator(ApplicationDbContext db)
    {
      this.db = db;
    }
    
    protected bool BeAValidUser(string userId)
    {
      return db.Users.Any(u => u.Id == userId);
    }

    protected bool ValidImage(IFormFile file)
    {
      if (file == null)
        return false;

      var allowedExtensions = new[] { ".png", ".jpeg", ".jpg" };
      var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();

      return allowedExtensions.Contains(fileExtension);

    }
  } 
}