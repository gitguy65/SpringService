using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Data;
using SpringService.Api.Models;

namespace SpringService.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/users");
            group.MapGet("/{id}", GetUser).WithName("get-user").WithOpenApi();
            group.MapPost("/create-user", CreateUser).WithName("create-user").WithOpenApi();
            group.MapPut("/update-user", UpdateUser).WithName("update-user").WithOpenApi();
            group.MapGet("/fetch-user-payments", FetchPayments).WithName("fetch-user-payments").WithOpenApi();
            group.MapGet("/fetch-user-history", FetchHistories).WithName("fetch-user-history").WithOpenApi();
            group.MapGet("/fetch-user-reviews", FetchReviews).WithName("fetch-user-reviews").WithOpenApi();
        }

        public static async Task<IResult> GetUser(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user is null)
                return Results.NotFound();

            return Results.Ok(user);
        }

        public static async Task<IResult> CreateUser(
            UserProfile userProfile, 
            IValidator<UserProfile> validator, 
            [FromServices] ApplicationDbContext dbContext)
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
                // create the user

                return Results.Ok("User created successfully");
            }
            catch (Exception ex)
            {
                // Log the exception details if necessary (using a logging framework)
                return Results.Problem("An error occurred while creating the user profile.", statusCode: 500);
            }
        }

        public static async Task<IResult> UpdateUser(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> FetchPayments(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> FetchHistories(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            throw new NotImplementedException();
        }
        public static async Task<IResult> FetchReviews(string id, [FromServices] UserManager<UserProfile> userManager)
        {
            throw new NotImplementedException();
        }
    }
}
