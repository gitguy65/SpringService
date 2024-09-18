using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Data;
using SpringService.Api.Models;

namespace SpringService.Api.Endpoints
{
    public static class HistoryEndpoints
    {
        public static void MapHistoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/histories");
            group.MapGet("/get-histories", GetHistories).WithName("get-histories").WithOpenApi();
            group.MapGet("/get-history", GetHistory).WithName("get-history").WithOpenApi();
            group.MapPost("/create-history", CreateHistory).WithName("create-history").WithOpenApi();
            group.MapPut("/update-history", UpdateHistory).WithName("update-history").WithOpenApi();
            group.MapDelete("/delete-history", DeleteHistory).WithName("delete-history").WithOpenApi();
        }

        public static async Task<IResult> GetHistories(
            string id,
            [FromServices] ApplicationDbContext db,
            [FromQuery(Name = "complete")] bool? doneFilter,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> GetHistory(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> CreateHistory(string userId, History booking)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> UpdateHistory(string userId, History booking, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> DeleteHistory(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
