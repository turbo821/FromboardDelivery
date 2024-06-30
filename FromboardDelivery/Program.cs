using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Models;
using FromboardDelivery.Services;
using FromboardDelivery.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
string email = builder.Configuration.GetSection("Credentials:Email").Value!;
string code = builder.Configuration.GetSection("Credentials:CodeApp").Value!;

builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();
builder.Services.AddDbContext<DeliveryContext>(options => options.UseSqlite(connection));
builder.Services.AddSingleton<IEmailSending>(new AdminEmailSender(new System.Net.NetworkCredential(email, code)));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
