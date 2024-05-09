using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using studmanagementsystemv13.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext service
//builder.Services.AddTransient<DbContext>(provider =>
//{
//    var configuration = provider.GetRequiredService<IConfiguration>();
//    var connectionString = configuration.GetConnectionString("DefaultConnection");
//    return new DbContext(connectionString);
//});

builder.Services.AddTransient<StudentContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new StudentContext(connectionString);
});
builder.Services.AddTransient<CourseContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new CourseContext(connectionString);
});
builder.Services.AddTransient<InstructorContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new InstructorContext(connectionString);
});
builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<DbContext>();
//        bool isConnected = context.TestConnection();
//        if (isConnected)
//        {
//            Console.WriteLine("Successfully connected to the database.");
//        }
//        else
//        {
//            Console.WriteLine("Failed to connect to the database.");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"An error occurred while checking the database: {ex.Message}");
//    }
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
