using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
builder.Services.AddSwaggerGen(options =>
{
    // Define the security scheme for the API key
    options.AddSecurityDefinition("TransportApiKey", new OpenApiSecurityScheme
    {
        Name = "TransportApiKey",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Please insert API key into field"
    });

    // Add a requirement to use the security scheme globally
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TransportApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

app.UseMiddleware<ApiKey>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
