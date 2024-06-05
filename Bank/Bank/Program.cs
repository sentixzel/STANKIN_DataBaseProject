using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
var builder = WebApplication.CreateBuilder(args);

/// Настройка Identity

// Настройка аутентификации
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddScoped<IPasswordHasher<Клиент>, PasswordHasher<Клиент>>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BankContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BankCS")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=Index}/{id?}");






///////// Настройка аутентификации
//////builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//////    .AddCookie(options =>
//////    {
//////        options.LoginPath = "/Account/Login";
//////    });

//////builder.Services.AddControllersWithViews();


//////if (!app.Environment.IsDevelopment())
//////{
//////    app.UseExceptionHandler("/Home/Error");
//////    app.UseHsts();
//////}

//////app.UseHttpsRedirection();
//////app.UseStaticFiles();

//////app.UseRouting();

//////// Используем аутентификацию и авторизацию
//////app.UseAuthentication();
//////app.UseAuthorization();

//////app.MapControllerRoute(
//////    name: "default",
//////    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
builder.Services.AddIdentity<Клиент, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true);

  
            ;