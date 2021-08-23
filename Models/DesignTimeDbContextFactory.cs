using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LeekQuest.Models
{
  public class LeekQuestContextFactory : IDesignTimeDbContextFactory<LeekQuestContext>
  {

    LeekQuestContext IDesignTimeDbContextFactory<LeekQuestContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<LeekQuestContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);

      return new LeekQuestContext(builder.Options);
    }
  }
}