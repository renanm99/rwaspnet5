using rwaspnet5.Services.Implementations;
using rwaspnet5.Services;
using rwaspnet5.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration["SQLConnection:SQLConnectionString"];
builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connectionString));

//Dependency Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
