using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddRazorPages();
builder.Services.AddDbContext<DeliveryContext>(options => options.UseSqlite(connection));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
