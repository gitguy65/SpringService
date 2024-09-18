using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpringService.Api.Data;
using SpringService.Api.Models;

namespace SpringService.Api.Endpoints
{
    public static class MasterEndpoints
    {
        public static void MapMasterEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/master");
            group.MapGet("/users", GetUsers).WithName("master-get-users").WithOpenApi(); 
            group.MapGet("/user/{id}", GetUser).WithName("master-get-user").WithOpenApi();
            group.MapGet("/get-bookings", GetBookings).WithName("master-get-bookings").WithOpenApi();
            group.MapGet("/get-booking", GetBooking).WithName("master-get-booking").WithOpenApi();
            group.MapGet("/get-hisotries", GetHistories).WithName("master-get-histories").WithOpenApi();
            group.MapGet("/get-hisotry/{id}", GetHistories).WithName("master-get-history").WithOpenApi();
            group.MapGet("/get-payments", GetPayments).WithName("master-get-payments").WithOpenApi();
            group.MapGet("/get-payments/{id}", GetPayments).WithName("master-get-payment").WithOpenApi();
            group.MapGet("/get-categories", GetCategories).WithName("master-get-categories").WithOpenApi();
            group.MapGet("/get-category/{id}", GetCategory).WithName("master-get-category").WithOpenApi();
            group.MapPost("/create-category", CreateCategory).WithName("master-create-category").WithOpenApi();
            group.MapPut("/update-category/{id}", UpdateCategory).WithName("master-update-category").WithOpenApi();
            group.MapDelete("/delete-category/{id}", DeleteCategory).WithName("master-delete-category").WithOpenApi();
        }
   
        public static async Task<IResult> GetUsers([FromServices] UserManager<UserProfile> userManager)
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
        }

        public static async Task<IResult> GetUser(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user is null)
                return Results.NotFound();

            return Results.Ok(user);
        }

        public static async Task<IResult> GetBookings([FromServices] ApplicationDbContext db)
        {
            var bookings = await db.Bookings.ToListAsync();
            if(bookings is null)
                return Results.NotFound();

            return Results.Ok(bookings);
        }

        public static async Task<IResult> GetBooking(int id, [FromServices] ApplicationDbContext db)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetHistories([FromServices] ApplicationDbContext db)
        {
            var histories = await db.Histories.ToListAsync();
            if (histories is null)
                return Results.NotFound();

            return Results.Ok(histories);
        }

        public static async Task<IResult> GetHistory(int id, [FromServices] ApplicationDbContext db)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetPayments([FromServices] ApplicationDbContext db)
        {
            var histories = await db.Histories.ToListAsync();
            if (histories is null)
                return Results.NotFound();

            return Results.Ok(histories);
        }

        public static async Task<IResult> GetPayment(int id, [FromServices] ApplicationDbContext db)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetCategories([FromServices] ApplicationDbContext db)
        {
            var histories = await db.Histories.ToListAsync();
            if (histories is null)
                return Results.NotFound();

            return Results.Ok(histories);
        }

        public static async Task<IResult> GetCategory(int id, [FromServices] ApplicationDbContext db)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> CreateCategory(string userId, Booking booking)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> UpdateCategory(string userId, Booking booking, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> DeleteCategory(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
