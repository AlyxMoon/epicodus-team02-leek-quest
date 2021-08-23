using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeekQuest.Models
{
  public class LeekQuestContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<UserRelationship> UserRelationships { get; set; }

    public LeekQuestContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}