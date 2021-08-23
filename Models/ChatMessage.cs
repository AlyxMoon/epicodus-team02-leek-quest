// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace LeekQuest.Models
{
  public class ChatMessage
  {
    // public Flavor()
    // {
    //   this.JoinEntities = new HashSet<FlavorTreat>();
    // }

    public int ChatMessageId { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    public string TimeStamp { get; set; }
    public int NumLikes { get; set; }
    public virtual ApplicationUser User { get; set; }
    // public virtual ICollection<FlavorTreat> JoinEntities { get; set; }
  }
}
