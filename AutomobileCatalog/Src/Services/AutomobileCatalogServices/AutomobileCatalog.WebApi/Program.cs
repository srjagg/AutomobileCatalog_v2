using AutomobileCatalog.Core.CoreImplement;
using AutomobileCatalog.Core.CoreInterface;
using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryImplement;
using AutomobileCatalog.Repositories.RepositoryInterface;
using AutomobileCatalog.UnitOfWork;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Inyectamos el contexto
builder.Services.AddDbContext<AutomobileCatalogDbContext>();

//UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//repositories
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();

//Core
builder.Services.AddScoped<ICarsCore, CarsCore>();
builder.Services.AddScoped<IBrandsCore, BrandsCore>();


// Add services to the container.

builder.Services.AddControllers();
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
