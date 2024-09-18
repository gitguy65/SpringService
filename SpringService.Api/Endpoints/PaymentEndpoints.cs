using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Data;
using SpringService.Api.Models;

namespace SpringService.Api.Endpoints
{
    public static class PaymentEndpoints
    {
        public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/payments");
            group.MapGet("/get-payments", GetPayments).WithName("get-payments").WithOpenApi();
            group.MapGet("/get-payment", GetPayment).WithName("get-payment").WithOpenApi();
            group.MapPost("/create-payment", CreatePayment).WithName("create-payment").WithOpenApi(); 
        }

        public static async Task<IResult> GetPayments(
            string id,
            [FromServices] ApplicationDbContext db,
            [FromQuery(Name = "complete")] bool? doneFilter,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> GetPayment(string userId, int bookingId)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> CreatePayment(string userId, Payment booking)
        {
            throw new NotImplementedException();
        }
    }

}
