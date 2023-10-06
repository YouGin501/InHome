using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using web_site_BAL.Contracts;
using web_site_BAL.Extensions;
using web_site_BAL.Services;
using web_site_DAL.Data;
using web_site_DAL.Repositories;
using web_site_Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScopedServices();
builder.Services.AddSingleton<AzureBlobService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*
var connectionString = builder.Configuration.GetConnectionString("Default");
//var connectionString = builder.Configuration.GetConnectionString("Docker");
builder.Services.AddDbContext<WebSiteDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors();

var serviceProvider = builder.Services.BuildServiceProvider();
SeedData.Initialize(serviceProvider);

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var appOrigins = "appOrigins";
builder.Services.AddCors();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: appOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200");
        }
    );
});

var app = builder.Build();

//*
app.UseDeveloperExceptionPage();
app.UseCors(
    options =>
        options
            .WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
);

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
