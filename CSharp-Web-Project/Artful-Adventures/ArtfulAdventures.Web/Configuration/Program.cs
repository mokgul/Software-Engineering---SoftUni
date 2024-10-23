using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArtfulAdventures.Data;
namespace ArtfulAdventures.Web.Configuration;

using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using ArtfulAdventures.Services.Data;
using ArtfulAdventures.Services.Data.Interfaces;
using ArtfulAdventures.Web.Areas.Admin.Services;
using ArtfulAdventures.Web.Areas.Admin.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<ArtfulAdventuresDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ArtfulAdventuresDbContext>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IPictureService, PictureService>();
        builder.Services.AddScoped<IExploreService, ExploreService>();
        builder.Services.AddScoped<IProfileService, ProfileService>();
        builder.Services.AddScoped<IFollowingService, FollowingService>();
        builder.Services.AddScoped<IChallengeService, ChallengeService>();
        builder.Services.AddScoped<IManageContentService, ManageContentService>();
        builder.Services.AddScoped<IManageUserService, ManageUserService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<IMessageService, MessageService>();
        builder.Services.AddScoped<ISearchService, SearchService>();

        var app = builder.Build();

        SyncData.ExecuteAsync();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        app.MapRazorPages();

        
        app.Run();

    }
}
