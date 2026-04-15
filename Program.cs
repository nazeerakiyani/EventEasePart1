using EventEasePart1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EventEaseDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"));

var app = builder.Build();

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

// CREATE DB + SEED DATA
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    if (!context.Venues.Any())
    {
        context.Venues.AddRange(
            new Venue { Name = "Durban City Hall", Location = "Durban CBD", Capacity = 500 },
            new Venue { Name = "ICC Durban", Location = "Exhibition Centre", Capacity = 5000 },
            new Venue { Name = "Conference Hall", Location = "Umhlanga", Capacity = 200 }
        );
        context.SaveChanges();
    }
}

app.Run();