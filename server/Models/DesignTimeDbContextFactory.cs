namespace LeekQuest.Models
{
  using System.IO;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Design;
  using Microsoft.Extensions.Configuration;
  public class LeekQuestContextFactory : IDesignTimeDbContextFactory<LeekQuestContext>
  {
    public LeekQuestContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<LeekQuestContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new LeekQuestContext(builder.Options);
    }
  }
}