// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace LeekQuest.Models
{
  public class UserRelationship
  {
    // public Flavor()
    // {
    //   this.JoinEntities = new HashSet<FlavorTreat>();
    // }

    public int User1Id { get; set; }
    public int User2Id { get; set; }
    public int NumNice { get; set; }
    public int NumMean { get; set; }
    public virtual ApplicationUser User { get; set; }
    // public virtual ICollection<FlavorTreat> JoinEntities { get; set; }
  }
}
