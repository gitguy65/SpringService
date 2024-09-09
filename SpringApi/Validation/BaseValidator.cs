using FluentValidation;
using SpringApi.Model;
using SpringApi.Data;


namespace SpringApi.Validation
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
    } 
}