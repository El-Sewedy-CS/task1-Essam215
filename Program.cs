using Demo_2.Models;
using Demo_2.Repo.Implementations;
using Demo_2.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register framework services BEFORE building the app
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MyAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IMenuItemRepo, MenuItemRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Map controller routes (default to Category/Index) and Razor Pages
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}