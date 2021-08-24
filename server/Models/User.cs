namespace LeekQuest.Models
{
  using System.Collections.Generic;
  using Microsoft.AspNetCore.Identity;
  public class User : IdentityUser
  {
    public User()
    {
      ChatMessages = new HashSet<ChatMessage>();
    }

    public int UserId { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string PlayerColor { get; set; }
    public bool InJail { get; set; }
    public virtual ICollection<ChatMessage> ChatMessages { get; set; }
  }
}