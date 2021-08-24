using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LeekQuest.Models
{
  public class User : IdentityUser
  {
    public User()
    {
      this.ChatMessages = new HashSet<ChatMessage>();
    }
    public int UserId { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int NumLikes { get; set; }
    public bool InJail { get; set; }
    public virtual ICollection<ChatMessage> ChatMessages { get; set; }
  }
}