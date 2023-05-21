using Food_ordering_3.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Food_ordering_3.Services;




namespace Academic_Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication();

            builder.Services.AddTransient<MySqlConnection>(_ =>
                new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<utsloverDbContext>();

            builder.Services.AddDbContext<utsloverDbContext>(options =>
            {
                options.UseMySql(
                    builder.Configuration.GetConnectionString("YourDbContext"),
                    new MySqlServerVersion(new Version(8, 0, 26)));
            });

            builder.Services.AddScoped<ICartService, CartService>(); // 添加购物车服务

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
