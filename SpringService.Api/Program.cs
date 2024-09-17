using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Validation;
using SpringService.Api.Util;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddIdentity<UserProfile, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.SeedTables();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Master

app.MapGet("/master/users", async ([FromServices] UserManager<UserProfile> userManager) =>
{
    try
    {
        var users = await userManager.Users.AsNoTracking().ToListAsync(); 
        return Results.Ok(users);
    }
    catch (Exception ex)
    {
        // Handle errors (log the error and return an appropriate response)
        return Results.Problem(detail: ex.Message, statusCode: 500);
    }
})
.WithName("Master-GetUsers")
.WithOpenApi();

app.MapGet("/master/user/{id}", async (string id, [FromServices]UserManager<UserProfile> userManager) =>
{
    var user = await userManager.FindByIdAsync(id);
    if (user is null)
        return Results.NotFound();

    return Results.Ok(user);
})
.WithName("Master-GetUser")
.WithOpenApi();

app.MapGet("/bookings/master", async ([FromServices]ApplicationDbContext db) =>
{
    var bookings = await db.Bookings.ToListAsync();
})
.WithName("Master-GetBookings")
.WithOpenApi();

app.MapGet("/histories/master", (string id) =>
{

})
.WithName("Master-GetHistory")
.WithOpenApi();

app.MapGet("/payments/master", (string id) =>
{

})
.WithName("Master-GetPayments")
.WithOpenApi();

#endregion

#region Users
app.MapGet("/user/{id}", (string id) =>
{
    // 
})
.WithName("GetUser")
.WithOpenApi();

app.MapPost("/create-user", async (
    UserProfile userProfile, 
    IValidator<UserProfile> validator, 
    [FromServices]ApplicationDbContext dbContext) =>
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
        // dbContext.UserProfiles.Add(userProfile);
        // await dbContext.SaveChangesAsync();

        return Results.Ok("User created successfully");
    }
    catch (Exception ex)
    {
        // Log the exception details if necessary (using a logging framework)
        return Results.Problem("An error occurred while creating the user profile.", statusCode: 500);
    }
})
.WithName("CreateUser")
.WithOpenApi();

app.MapPut("/update-user/{id}", (string userId) =>
{
    //
});

app.MapPost("/delete-user/{id}", (string userId) =>
{
    //
});

app.MapGet("/user-reviews/{id}", (string userId) =>
{
    //
});

app.MapGet("/user-history/{id}", (string userId) =>
{
    //
});

app.MapGet("/user-payments/{id}", (string userId) =>
{
    //
});

app.MapGet("/user-complete/{id}", () =>
{
    //
});


#endregion

#region Bookings

app.MapGet("/bookings/{id}", async (
    [FromServices]ApplicationDbContext db,
    string id,
    [FromQuery(Name = "complete")] bool? doneFilter,
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

app.MapDelete("/delete-booking/{id}", (string user) =>
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

app.MapPost("/create-category", () =>
{

});

app.MapPut("/update-category", () =>
{

});

app.MapDelete("/delete-category", () =>
{

});
#endregion

#region History
app.MapGet("/histories/{id}", (string user) =>
{

});

app.MapGet("/history/{id}", (string user) =>
{

});

app.MapPost("/create-history/{id}", (string user) =>
{

});

app.MapDelete("/update-history/{id}", (string user) =>
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

app.Run();
