using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.DAL;

namespace OlympicMedalistBoard;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<OlympicMedalistBoardDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<OlympicMedalistBoardDbContext>()
                .AddDefaultUI();
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<AthleteDAL>();
        builder.Services.AddScoped<AthleteService>();

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        app.Run();
    }
}
