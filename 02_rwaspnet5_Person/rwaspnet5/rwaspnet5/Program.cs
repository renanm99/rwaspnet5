using rwaspnet5.Business.Implementations;
using rwaspnet5.Business;
using rwaspnet5.Model.Context;
using Microsoft.EntityFrameworkCore;
using rwaspnet5.Repository;
using Serilog;
using EvolveDb;
using Microsoft.Data.SqlClient;
using rwaspnet5.Repository.Generic;
using rwaspnet5.Hypermedia.Filters;
using rwaspnet5.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

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

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
}
).AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFiltersOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

// API Versioning
builder.Services.AddApiVersioning();

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "REST API's from 0 to Azure with ASP.NET Core 5 and Docker",
        Version = "v1",
        Description = "API RESTFul developed in course 'rwaspnet5'",
        Contact = new OpenApiContact
        {
            Name = "Renan Machado",
            Url = new Uri("https://www.linkedin.com/in/renanoliveiram/")
        }
    }
    );
});

// Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Use Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json"
    , "REST API's from 0 to Azure with ASP.NET Core 5 and Docker");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


//Use UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

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