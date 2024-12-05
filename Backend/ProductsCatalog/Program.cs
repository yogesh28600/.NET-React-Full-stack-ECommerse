using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Context;
using ProductsCatalog.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseMongoDB(Environment.GetEnvironmentVariable("MONGO_URI"), "Products"));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
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
