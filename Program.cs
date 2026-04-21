using entityframeworkcodebaseapproachwithdiftdb.DBcontext;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using entityframeworkcodebaseapproachwithdiftdb.Repositories;
using entityframeworkcodebaseapproachwithdiftdb.services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCodeFirstApproachDatabase"));
});
builder.Services.AddDbContext<DepartmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DepartmentCodeFirstApproachDatabase"));
});
builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderCodeFirstApproachDatabase"));
});
builder.Services.AddScoped<Iemployeerepository, Employeerepository>();
builder.Services.AddScoped<Iemployeeseervice, Employeeservice>();
builder.Services.AddScoped<Idepartmentrepository, Departmentrepository>();
builder.Services.AddScoped<Idepartmentservice, Departmentservice>();
builder.Services.AddScoped<IOrdersrepository, Orderrepository>();
builder.Services.AddScoped<IOrderservice, Orderservice>();
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
