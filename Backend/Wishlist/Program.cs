using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Wishlist.Context;
using Wishlist.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WishlistContext>(options => options.UseMongoDB(Environment.GetEnvironmentVariable("MONGO_URI"), "Wishlist"));
builder.Services.AddScoped<IWishlistRepo, WishlistRepo>();
var app = builder.Build();
Env.Load();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
