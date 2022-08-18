

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapControllerRoute(
    name: "controller",
    pattern: "api/{controller=Home}/{action=Index}/{id?}");
app.Run();
