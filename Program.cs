using Microsoft.EntityFrameworkCore;
using soa_ca2.Middleware;
using soa_ca2.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

//Mj6YSQJunpH3XmL
var ServerVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connectionString = "Server=d00239107-soa-ca2.mysql.database.azure.com; Database=transportation_soa_ca2; User=d00239107; Password=Mj6YSQJunpH3XmL";

builder.Services.AddDbContext<TravelContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion,
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

//app.UseMiddleware<ApiKey>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
