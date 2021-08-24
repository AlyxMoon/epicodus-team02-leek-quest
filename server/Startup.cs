using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

using LeekQuest.Models;

namespace LeekQuest
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddDbContext<LeekQuestContext>(opt => opt.UseMySql(
        Configuration["ConnectionStrings:DefaultConnection"], 
        ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])
      ));

      services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<LeekQuestContext>()
        .AddDefaultTokenProviders();

      // In production, the React files will be served from this directory
      // services.AddSpaStaticFiles(configuration =>
      // {
      //   configuration.RootPath = "client/build";
      // });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseAuthentication(); 
      // app.UseHttpsRedirection();
      app.UseStaticFiles();
      // app.UseSpaStaticFiles();

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
      });

      // app.UseSpa(spa =>
      // {
      //   spa.Options.SourcePath = "client";

      //   if (env.IsDevelopment())
      //   {
      //     spa.UseReactDevelopmentServer(npmScript: "serve");
      //   }
      // });
    }
  }
}
