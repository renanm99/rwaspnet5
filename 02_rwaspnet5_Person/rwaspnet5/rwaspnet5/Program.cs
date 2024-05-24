using rwaspnet5.Business.Implementations;
using rwaspnet5.Business;
using rwaspnet5.Model.Context;
using Microsoft.EntityFrameworkCore;
using rwaspnet5.Repository;
using Serilog;
using EvolveDb;
using Microsoft.Data.SqlClient;
using rwaspnet5.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Database
var connectionString = builder.Configuration["SQLConnection:SQLConnectionString"];
builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connectionString));

// Migration
if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connectionString);
}

// API Versioning
builder.Services.AddApiVersioning();

// Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Migration Database
void MigrateDatabase(string connectionString)
{
    try
    {
        var evolveConnection = new SqlConnection(connectionString);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("", ex);
        throw;
    }
}