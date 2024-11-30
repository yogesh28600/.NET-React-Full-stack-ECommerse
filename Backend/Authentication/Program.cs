using Authentication.Context;
using Authentication.Repositories.UserRepository;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(options =>options.UseMongoDB(Environment.GetEnvironmentVariable("MONGO_URI"),"Users"));
builder.Services.AddScoped<IUserRepo,UserRepo>();
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
