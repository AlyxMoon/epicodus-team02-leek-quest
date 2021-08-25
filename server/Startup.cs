namespace LeekQuest
{
  using System.Text;
  using LeekQuest.Models;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Microsoft.IdentityModel.Tokens;
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
      services.AddCors(options =>
      {
        options.AddPolicy("AllowSpecificOrigin",
          builder =>
          {
            builder.WithOrigins("http://localhost:5000", "https://localhost:5001", "http://localhost:8080");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
          });
      });

      string config = Configuration["ConnectionStrings:DefaultConnection"];
      ServerVersion version = ServerVersion.AutoDetect(config);

      services.AddControllersWithViews();
      services.AddDbContext<LeekQuestContext>(opt => opt.UseMySql(config, version));

      services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<LeekQuestContext>()
        .AddDefaultTokenProviders();

      services
        .AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
              ValidateIssuer = false,
              ValidateAudience = false,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
            };
        });

      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;
      });

      services.AddCors(options =>
      {
        options.AddPolicy("AllowSpecificOrigin",
          builder =>
          {
            builder.WithOrigins("http://localhost:5000", "https://localhost:5001", "http://localhost:8080");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
          });
      });

      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "../client/build";
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseAuthentication();
      app.UseStaticFiles();

      app.UseRouting();
      app.UseCors("AllowSpecificOrigin");
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
      });

      app.UseSpaStaticFiles();
      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "../client";
        if (env.IsDevelopment())
        {
          spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
        }
      });
    }
  }
}
