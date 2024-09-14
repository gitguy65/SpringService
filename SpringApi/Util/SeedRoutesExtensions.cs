using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpringApi.Data;
using SpringApi.Model;

namespace SpringApi.Util
{
    // SeedRoutesExtensions.cs
    public static class SeedRoutesExtensions
    {
        public static void SeedTables(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/seed-tables", async (ApplicationDbContext db) =>
            {
                using var transaction = await db.Database.BeginTransactionAsync();
                try
                {
                    await db.Bookings.ExecuteDeleteAsync();
                    await db.Categories.ExecuteDeleteAsync();
                    await db.UserProfiles.ExecuteDeleteAsync();
                    await db.Histories.ExecuteDeleteAsync();
                    await db.Reviews.ExecuteDeleteAsync();
                    await db.Schedules.ExecuteDeleteAsync();
                    await db.Services.ExecuteDeleteAsync();
                    await db.Payments.ExecuteDeleteAsync();

                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('UserProfiles', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Bookings', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Categories', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Reviews', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Histories', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Schedules', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Services', RESEED, 0)");
                    await db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Payments', RESEED, 0)");

                    // Fill all tables with random data
                    var userFaker = new Faker<UserProfile>()
                        .RuleFor(u => u.Slug, f => f.Lorem.Slug())
                        .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                        .RuleFor(u => u.LastName, f => f.Name.LastName())
                        // .RuleFor(u => u.ProfilePicture, f => null) 
                        .RuleFor(c => c.ProfilePicture, f => new FormFile(Stream.Null, 0, 0, "ProfilePicture", "empty.png")) 
                        .RuleFor(x => x.Password, f => GeneratePassword()) 
                        .RuleFor(x => x.ConfirmPassword, (f, u) => u.Password)
                        .RuleFor(u => u.Balance, f => f.Random.Double(0, 10000))
                        .RuleFor(u => u.Address, f => f.Address.FullAddress())
                        .RuleFor(u => u.IsVerified, f => f.Random.Bool())
                        .RuleFor(u => u.Designation, f => f.Company.CatchPhrase())
                        .RuleFor(u => u.Details, f => f.Lorem.Paragraph())
                        .RuleFor(u => u.Experience, f => f.Lorem.Sentence())
                        .RuleFor(u => u.Qualification, f => f.Lorem.Sentence())
                        .RuleFor(u => u.Social, f => f.Make(3, () => f.Internet.DomainWord()).ToArray())
                        .RuleFor(u => u.GivenReviews, f => new List<Review>())
                        .RuleFor(u => u.ReceivedReviews, f => new List<Review>())
                        .RuleFor(u => u.Bookings, f => new List<Booking>())
                        .RuleFor(u => u.Histories, f => new List<History>())
                        .RuleFor(u => u.Payments, f => new List<Payment>())
                        .RuleFor(u => u.IsSubscribedToNewsletter, f => f.Random.Bool())
                        .RuleFor(u => u.RecieveNotifications, f => f.Random.Bool())
                        .RuleFor(u => u.IsDeleted, f => f.Random.Bool());
                    var users = userFaker.Generate(10);

                    var bookingFaker = new Faker<Booking>()
                        .RuleFor(b => b.UserId, f => f.PickRandom(users).Id)
                        .RuleFor(t => t.Description, f => f.Lorem.Word())
                        .RuleFor(b => b.UserProfile, f => f.PickRandom(users))
                        .RuleFor(b => b.BookingDate, f => f.Date.Past())
                        .RuleFor(b => b.StartDate, f => f.Date.Future())
                        .RuleFor(b => b.Duration, f => f.Random.Int(1, 48))
                        .RuleFor(b => b.PaymentType, f => (PaymentType)f.Random.Int(0, 2))
                        .RuleFor(b => b.Amount, f => f.Random.Double(0, 10000))
                        .RuleFor(b => b.Charge, f => f.Random.Double(0, 10000))
                        .RuleFor(b => b.Description, f => f.Lorem.Sentence())
                        .RuleFor(b => b.Message, f => f.Lorem.Sentence())
                        .RuleFor(b => b.Longitude, f => f.Address.Longitude())
                        .RuleFor(b => b.Latitude, f => f.Address.Latitude())
                        .RuleFor(b => b.IsAccepted, f => f.Random.Bool())
                        .RuleFor(b => b.IsPaymentConfirmed, f => f.Random.Bool())
                        .RuleFor(b => b.IsJobCompleted, f => f.Random.Bool())
                        .RuleFor(b => b.IsJobCanceled, f => f.Random.Bool())
                        .RuleFor(b => b.IsDeleted, f => f.Random.Bool());
                    var bookings = bookingFaker.Generate(60);

                    var categories = new Faker<Category>()
                        .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                        .RuleFor(c => c.Name, f => f.Commerce.Department())
                        .RuleFor(c => c.Slug, f => f.Lorem.Slug()) 
                        // .RuleFor(c => c.CategoryImage, f => null) 
                        .RuleFor(c => c.CategoryImage, f => new FormFile(Stream.Null, 0, 0, "CategoryImage", "empty.png"))
                        .RuleFor(c => c.CategoryImageUrl, f => f.Image.PicsumUrl())
                        .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                        .RuleFor(c => c.Status, f => f.Random.Bool())
                        .Generate(10);

                    var reviews = new Faker<Review>()
                        .RuleFor(r => r.Id, f => f.IndexFaker + 1)
                        .RuleFor(r => r.ServiceCategory, (f, r) => f.PickRandom(categories).Name) 
                        .RuleFor(r => r.ServiceUser, f => f.PickRandom(users))
                        .RuleFor(r => r.ServiceUserId, (f, r) => r.ServiceUser.Id)
                        .RuleFor(r => r.ServiceProvider, f => f.PickRandom(users))
                        .RuleFor(r => r.ServiceProviderId, (f, r) => r.ServiceProvider.Id)
                        .RuleFor(r => r.Time, f => f.Date.Past(1))
                        .RuleFor(r => r.Message, f => f.Lorem.Sentence())
                        .RuleFor(r => r.Star, f => Math.Round(f.Random.Double(0, 5), 1))
                        .Generate(10);

                    var histories = new Faker<History>()
                        .RuleFor(h => h.Id, f => f.IndexFaker + 1)
                        .RuleFor(b => b.UserId, f => f.PickRandom(users).Id)
                        .RuleFor(h => h.UserProfile, f => f.PickRandom(users))
                        .RuleFor(h => h.ServiceId, f => f.IndexFaker + 1)
                        .RuleFor(h => h.Amount, f => f.Random.Double(0, 10000))
                        .RuleFor(h => h.Currency, f => f.Finance.Currency().Code)
                        .RuleFor(h => h.Charge, f => f.Random.Double(0, 10000))
                        .RuleFor(h => h.Commission, f => f.Random.Double(0, 10000))
                        .RuleFor(h => h.Details, f => f.Lorem.Paragraph())
                        .RuleFor(h => h.Type, f => f.Lorem.Word())
                        .Generate(10);

                    var schedules = new Faker<Schedule>()
                        .RuleFor(b => b.UserId, f => f.PickRandom(users).Id)
                        .RuleFor(s => s.UserProfile, f => f.PickRandom(users))
                        .RuleFor(s => s.WeekName, f => f.PickRandom(Enum.GetNames(typeof(DayOfWeek)))) 
                        .RuleFor(s => s.StartTime, f => f.Date.Soon())
                        .RuleFor(s => s.EndTime, (f, s) => f.Date.Between(s.StartTime.AddHours(30), s.StartTime.AddHours(100))) 
                        .RuleFor(s => s.Status, f => f.Random.Bool())
                        .Generate(10);

                    var services = new Faker<Service>()
                        .RuleFor(s => s.Id, f => f.IndexFaker + 1)
                        .RuleFor(s => s.Description, f => f.Lorem.Sentence())
                        .RuleFor(s => s.UserProfile, f => f.PickRandom(users))
                        .Generate(10);

                    var payments = new Faker<Payment>()
                        .RuleFor(b => b.UserId, f => f.PickRandom(users).Id)
                        .RuleFor(p => p.UserProfile, f => f.PickRandom(users))
                        .RuleFor(p => p.ServiceId, f => f.Random.AlphaNumeric(10))
                        .RuleFor(p => p.Amount, f => f.Random.Double(0, 10000))
                        .RuleFor(p => p.Currency, f => f.Finance.Currency().Code)
                        .RuleFor(p => p.Charge, f => f.Random.Double(0, 10000))
                        .RuleFor(p => p.Commission, f => f.Random.Double(0, 10000))
                        .RuleFor(p => p.Details, f => f.Lorem.Paragraph())
                        .RuleFor(p => p.PaymentType, f => (PaymentType)f.Random.Int(0, 2))
                        .Generate(10);


                    await db.UserProfiles.AddRangeAsync(users);
                    await db.Bookings.AddRangeAsync(bookings);
                    await db.Categories.AddRangeAsync(categories);
                    await db.Reviews.AddRangeAsync(reviews);
                    await db.Histories.AddRangeAsync(histories);
                    await db.Schedules.AddRangeAsync(schedules);
                    await db.Services.AddRangeAsync(services);
                    await db.Payments.AddRangeAsync(payments);

                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    Console.WriteLine(ex.Message);
                    return Results.Problem(detail: ex.Message, statusCode: 500);
                }
            });
        }

        // private static async Task SeedDatabase(ApplicationDbContext db)
        // {
        //     // Add your seeding logic here
        //     // For example: await db.SeedDataAsync();
        // }


        private static string GeneratePassword()
        {
            var faker = new Faker();
            int upperCaseCount = faker.Random.Int(1, 2); 
            string upperCase = new string(Enumerable.Range(0, upperCaseCount).Select(_ => faker.Random.AlphaNumeric(1).ToUpper()[0]).ToArray()); 
            string lowerCase = faker.Random.AlphaNumeric(1).ToLower(); 
            string digit = faker.Random.Number(0, 9).ToString(); 
            string specialChar = faker.Random.String2(1, "!@#$%^&*()"); 
            string remainingChars = faker.Random.AlphaNumeric(8 - upperCase.Length - 3); 

            string password = upperCase + lowerCase + digit + specialChar + remainingChars;
            return new string(password.OrderBy(c => Guid.NewGuid()).ToArray()); 
        }
    }
}



