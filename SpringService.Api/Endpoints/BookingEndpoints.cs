using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Data;
using SpringService.Api.Models;

namespace SpringService.Api.Endpoints
{
    public static class BookingEndpoints
    {
        public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/bookings");
            group.MapGet("/get-bookings", GetBookings).WithName("get-bookings").WithOpenApi();
            group.MapGet("/get-booking", GetBooking).WithName("get-booking").WithOpenApi();
            group.MapPost("/create-booking", CreateBooking).WithName("create-booking").WithOpenApi();
            group.MapPut("/update-booking", UpdateBooking).WithName("update-booking").WithOpenApi();
            group.MapDelete("/delete-booking", DeleteBooking).WithName("delete-booking").WithOpenApi();
        }

        public static async Task<IResult> GetBookings(
            string id,
            [FromServices] ApplicationDbContext db,
            [FromQuery(Name = "complete")] bool? doneFilter,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> GetBooking(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> CreateBooking(string userId, Booking booking)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> UpdateBooking(string userId, Booking booking, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> DeleteBooking(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
