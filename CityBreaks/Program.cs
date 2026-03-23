using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CityBreaksContext>();

    db.Countries.Add(new Country
    {
        CountryCode = "BR",
        CountryName = "Brazil"
    });

    db.SaveChanges();
}

app.Run();