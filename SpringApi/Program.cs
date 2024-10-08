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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer(); 

var app = builder.Build(); 
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SeedTables();

#region Master
app.MapGet("/master/users", async (ApplicationDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
})
.WithName("GetAllUsers")
.WithOpenApi(); ;

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

app.MapPost("/create-user", async (UserProfile userProfile, IValidator<UserProfile> validator, ApplicationDbContext dbContext) =>
{
    var validationResult = validator.Validate(userProfile);
    if (!validationResult.IsValid)
        return Results.ValidationProblem(validationResult.ToDictionary());

    string profilePictureUrl = null;
    if (userProfile.ProfilePicture != null)
    {
        var uploadResult = await ImageUpload.UploadAsync(userProfile.ProfilePicture);
        if (uploadResult is string errorMessage)
            return Results.BadRequest(errorMessage);
        
        profilePictureUrl = uploadResult;
    }
    
    userProfile.ProfilePictureUrl = profilePictureUrl;
    try
    {
        dbContext.UserProfiles.Add(userProfile);
        await dbContext.SaveChangesAsync();

        return Results.Ok("User created successfully");
    }
    catch (Exception ex)
    {
        // Log the exception details if necessary (using a logging framework)
        return Results.Problem("An error occurred while creating the user profile.", statusCode: 500);
    }
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

#endregion

app.Run();