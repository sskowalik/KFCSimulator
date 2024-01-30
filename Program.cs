global using Microsoft.EntityFrameworkCore;
global using KFCSimulator.Models;
global using KFCSimulator.Services.UserService;
global using KFCSimulator.Services.ShiftService;
global using KFCSimulator.Services.OrderService;
global using KFCSimulator.Services.MenuService;
global using KFCSimulator.Services.DepartmentService;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddSwaggerGen();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Configuration.AddConfiguration(configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
