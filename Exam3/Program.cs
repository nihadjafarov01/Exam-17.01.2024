using Exam3.DAL;
using Exam3.Business;
using Exam3.Business.Profiles;
using Exam3.Core.Models;
using Microsoft.AspNetCore.Identity;
using Exam3.DAL.Contexts;

namespace Exam3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext(builder.Configuration.GetConnectionString("MSSql"));

            builder.Services.AddRepositories();

            builder.Services.AddServices();

            builder.Services.AddMappers(builder.Environment);

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;

                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";

                opt.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<Exam3DbContext>().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = "/auth/AccessDeniedPath";
                opt.LoginPath = "/auth/login";
                opt.LogoutPath = "/auth/logout";

                opt.Cookie.Name = "IdentityCookie";
            });

            //builder.Services.AddIdentity<AppUser,IdentityRole>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Card}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}