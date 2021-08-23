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
    public string Position { get; set; }
    public int NumLikes { get; set; }

    public bool InJail { get; set; }
    public virtual ICollection<ChatMessage> ChatMessages { get; set; }
  }
}