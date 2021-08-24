namespace LeekQuest.Models
{
  using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore;
  public class LeekQuestContext : IdentityDbContext<User>
  {
    // public override DbSet<User> Users { get; set; }
    // Roles, UserRoles, Users
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<UserRelationship> UserRelationships { get; set; }

    public LeekQuestContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}