using Azure;
using Bogus;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpringApi.Data;
using SpringApi.Model;
using SpringApi.Util;
using SpringApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<UserProfile>, UserProfileValidator>();
builder.Services.AddScoped<IValidator<Booking>, BookingValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<History>, HistoryValidator>();
builder.Services.AddScoped<IValidator<Review>, ReviewValidator>();
builder.Services.AddScoped<IValidator<Schedule>, ScheduleValidator>();
builder.Services.AddScoped<IValidator<Service>, ServiceValidator>();
builder.Services.AddScoped<IValidator<Payment>, PaymentValidator>();

builder.Services.AddEndpointsApiExplorer(); 

var app = builder.Build(); 
app.UseHttpsRedirection();

app.SeedTables();

#region Master
app.MapGet("/master/users", async (ApplicationDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

app.MapGet("/master/user{id}", async (string id, ApplicationDbContext db) =>
{
    var user = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    if(user is null)
        return Results.NotFound();

    return Results.Ok(user);
});

app.MapGet("/bookings/master", async (ApplicationDbContext db) =>
{
    var bookings = await db.Bookings.ToListAsync();
});

app.MapGet("/histories/master", (UserProfile master) =>
{

});

app.MapGet("/payments/master", (UserProfile master) =>
{

});
#endregion

#region Users
app.MapGet("/user/{id}", (string id) =>
{
    // 
});

app.MapPost("/create-user", (UserProfile userProfile, IValidator<UserProfile> validator) =>
{
    var validationResult = validator.Validate(userProfile);
    if (!validationResult.IsValid)
        return Results.ValidationProblem(validationResult.ToDictionary());

    // add booking

    return Results.Ok();
});

app.MapPut("/update-user/{id}", (string UserSlug) =>
{
    //
});

app.MapPost("/delete-user/{id}", (string UserSlug) =>
{
    //
});

app.MapGet("/user-reviews/{id}", (string UserSlug) =>
{
    //
});

app.MapGet("/user-history/{id}", (string UserSlug) =>
{
    //
});
app.MapGet("/user-payments/{id}", (string UserSlug) =>
{
    //
});

app.MapGet("/user-complete/{id}", () =>
{
    //
});
#endregion

#region Bookings

app.MapGet("/bookings/{id}", (UserProfile user, 
    ApplicationDbContext db,
    [FromQuery(Name = "q")] string? titleFilter,
    [FromQuery(Name = "done")] bool? doneFilter,
    [FromQuery] int? skip,
    [FromQuery] int? take) =>
{
    // var query = await db.Bookings.GetFilteredBookings(titleFilter, doneFilter, skip, take);
    // return query.Select(BuildTodoSummary);
});

app.MapGet("/booking/{id}", (int id) =>
{
    // 
});

app.MapPost("/create-booking", (Booking booking, IValidator<Booking> validator) =>
{
    var validationResult = validator.Validate(booking);
    if (!validationResult.IsValid)
        return Results.ValidationProblem(validationResult.ToDictionary());

    // add booking

    return Results.Ok();
});

app.MapPut("/update-booking/{id}", (int id, Booking booking, IValidator<Booking> validator) =>
{
    var validationResult = validator.Validate(booking);
    if (!validationResult.IsValid)
        return Results.ValidationProblem(validationResult.ToDictionary());
    
    
    return Results.Ok($"Booking with ID {id} has been updated successfully.");
});

app.MapDelete("/delete-booking/{id}", (UserProfile user) =>
{
    // 
});
#endregion

#region Categories
app.MapGet("/categories", () =>
{

});
app.MapGet("/category/{id}", (int id) =>
{

});

app.MapPost("/create-category", (UserProfile UserProfile) =>
{

});

app.MapPut("/update-category", (UserProfile UserProfile) =>
{

});

app.MapDelete("/delete-category", (UserProfile UserProfile) =>
{

});
#endregion

#region History
app.MapGet("/histories/{id}", (UserProfile user) =>
{

});

app.MapGet("/history/{id}", (UserProfile user) =>
{

});

app.MapPost("/create-history/{id}", (UserProfile user) =>
{

});

app.MapDelete("/update-history/{id}", (UserProfile user) =>
{

});
#endregion

#region Payment
app.MapGet("/payments/{id}", () =>
{

});

app.MapGet("/payment/{id}", () =>
{

});

app.MapPost("/payment/{id}", () =>
{

});

app.MapPut("/payment/{id}", () =>
{

});

app.MapDelete("/payment/", () =>
{

});
#endregion



#region DTO
// public record UserProfile( 
//         string Slug,
//         string FirstName,
//         string LastName,
//         IFormFile ProfilePicture,
//         double Balance,
//         string Address, 
//         bool IsVerified,
//         string? Designation,
//         string? Details,
//         string? Experience,
//         string? Qualification,
//         string[] Social,
//         ICollection<Review>? GivenReviews,
//         ICollection<Review>? ReceivedReviews,
//         ICollection<Booking>? Bookings,
//         ICollection<History>? Histories,
//         ICollection<Payment>? Payments,
//         bool IsSubscribedToNewsletter,
//         bool RecieveNotifications
//     );

// public record Booking( 
//         int UserId,
//         UserProfile UserProfile,
//         DateTime BookingDate,
//         DateTime StartDate,
//         int Duration,
//         PaymentType PaymentType,
//         double Amount,
//         double Charge,
//         string Description,
//         string Message,
//         double Longitude,
//         double Latitude,
//         bool IsAccepted,
//         bool IsPaymentConfirmed,
//         bool IsJobCompleted,
//         bool IsJobCanceled,
//         bool IsDeleted
//     );

// public record History( 
//         int UserId,
//         UserProfile UserProfile,
//         int ServiceId,
//         double Amount,
//         string Currency,
//         double Charge,
//         double Commission,
//         string Details,
//         string Type
//     );

// public record Category(
//         int Id,
//         string Name,
//         string Slug,
//         string Image,
//         string Description,
//         bool Status
//     );

// public record Review(
//         int Id,
//         string ServiceCategory,
//         int ServiceUserId,
//         UserProfile ServiceUser,
//         int ServiceProviderId,
//         UserProfile ServiceProvider,
//         DateTime Time,
//         string Message,
//         double Star
//     );


// public record Schedule( 
//         int Id,
//         int UserId,
//         UserProfile UserProfile,
//         string WeekName,
//         string StartTime,
//         string EndTime,
//         bool Status
//     );

// public record Service(
//         int Id,
//         string Description,
//         UserProfile UserProfile
//     );

// public record Payment(
//         int Id,
//         int UserId,
//         UserProfile UserProfile,
//         string ServiceId,
//         double Amount,
//         string Currency,
//         double Charge,
//         double Commission,
//         string Details,
//         PaymentType PaymentType
//     );

#endregion
