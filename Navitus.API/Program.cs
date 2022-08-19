using Business.Interfaces;
using Business.Services;
using Navitus.Repository.DBConfig;
using Repository.SqlDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IDbConfiguration, DbConfiguration>();
builder.Services.AddDbContext<SqlConnection>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "controller",
    pattern: "api/{controller=Home}/{action=Index}/{id?}");
app.Run();
