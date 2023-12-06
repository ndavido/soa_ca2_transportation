using Microsoft.EntityFrameworkCore;
using soa_ca2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var ServerVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connectionString = "Server=localhost; Database=transportation_soa_ca2; User=root; Password=";

builder.Services.AddDbContext<TravelContext>(opt => opt.UseMySql(connectionString, ServerVersion));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
