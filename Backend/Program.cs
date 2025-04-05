using Backend.Data;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string? connectionString = builder.Configuration.GetConnectionString("AgendaDataBase");

if (connectionString is null)
{
    throw new Exception("The connection string was not defined in appsettings");
}

builder.Services.AddDbContext<AgendaContext>(opt => opt.UseNpgsql(connectionString));

// Dependency Injection for repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PersonalCalendarRepository>(); 

// Dependency Injection for services
builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<PersonalCalendarService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
