using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD_Feb1.Models;
using WebAPI_CRUD_Feb1.Models.DataManager;
using WebAPI_CRUD_Feb1.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProjectContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("ProjectCon")));

builder.Services.AddScoped<IDataRepository<Product>, ProductManager>();//DEPENDENCY INJECTION
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
