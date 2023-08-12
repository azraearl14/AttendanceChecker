using AttendanceChecker.Models;
using AttendanceChecker.Views.Custom;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<UserDBContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Cookie"; // Customize the cookie name
        options.LoginPath = "/Home/Login"; // Specify the login page
    });

builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    options => options.EnableRetryOnFailure()));

//builder.Services.AddIdentity<UserModel, IdentityRole>()
//    .AddEntityFrameworkStores<UserDBContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<UserDBContext>();

//builder.Services.AddIdentity<UserModel, IdentityRole<int>>() // Use UserModel here
//            .AddEntityFrameworkStores<UserDBContext>()
//            .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
    });

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
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
