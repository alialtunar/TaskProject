using Microsoft.EntityFrameworkCore;
using TaskProject.BussinesLayer.Abstract;
using TaskProject.BussinesLayer.Concreate;
using TaskProject.DataAccessLayer.Abstract;
using TaskProject.DataAccessLayer.Concreate;
using TaskProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Binding product service and data access layer dependencies
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();


// Database connection
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
