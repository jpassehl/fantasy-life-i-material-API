using fantasy_life_i_material_API.Data;
using fantasy_life_i_material_API.Repositories;
using fantasy_life_i_material_API.Services.MaterialService;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore; // Ensure this using directive is present

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//Add repositories
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
// Add services to the container.
builder.Services.AddScoped<IMaterialService, MaterialService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add DbContext
builder.Services.AddDbContext<MaterialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
