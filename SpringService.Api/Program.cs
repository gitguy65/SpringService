using FluentValidation; 
using Microsoft.EntityFrameworkCore;
using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Validation;
using SpringService.Api.Util;
using Microsoft.AspNetCore.Identity;
using SpringService.Api.Endpoints;

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

app.MapMasterEndpoints();
app.MapUserEndpoints();
app.MapBookingEndpoints();
app.MapHistoryEndpoints();
app.MapPaymentEndpoints();

app.UseHttpsRedirection();


app.Run();
