using Accruent.Data.Contexts;
using Accruent.Data.Interfaces;
using Accruent.Data.Repositories;
using Accruent.Domain.Interfaces;
using Accruent.Domain.Services;
using Accruent.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AccruentDbContext>((provider, options) =>
{
    options.UseSqlServer(connectionString);
});

builder.Services
        .AddCors(options =>
        {
            options.AddPolicy(name: "Default",
                              policy =>
                              {
                                  policy.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                              });
        })
       .AddScoped<IBaseRepository<Product>, ProductRepository>()
       .AddScoped<IBaseRepository<Movement>, MovementRepository>()
       .AddScoped<IReportService, ReportService>()
       .AddTransient<IMovementService, MovementService>()
            .Decorate<IMovementService, MovementServiceSaving>()
            .Decorate<IMovementService, MovementServiceValidation>()
            .Decorate<IMovementService, MovementServiceProcess>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("Default");

app.UseAuthorization();

app.MapControllers();

app.Run();



