using Backend.Data;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string? connectionString = builder.Configuration.GetConnectionString("AgendaDataBase");

if(connectionString is null )
{
    throw new Exception("A string de conexão não foi definida no appsetings");
}

builder.Services.AddDbContext<AgendaContext> (opt => opt.UseNpgsql(connectionString));

builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
