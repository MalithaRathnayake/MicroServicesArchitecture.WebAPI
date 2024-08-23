using KooBits.MicroServices.OrderServices.Infrastructure;
using KooBits.MicroServices.OrderServices.Infrastructure.Repositories;
using KooBits.MicroServices.OrderServices.Interfaces;
using KooBits.MicroServices.OrderServices.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(); // Add HttpClient services
builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDBContext>(opt => opt.UseInMemoryDatabase("OrderDb"));


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
