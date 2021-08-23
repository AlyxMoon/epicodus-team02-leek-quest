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
    public int UserRelationshipId { get; set; }
    public string User1Id { get; set; }
    public string User2Id { get; set; }
    public int NumNice { get; set; }
    public int NumMean { get; set; }
    public virtual User User { get; set; }
    // public virtual ICollection<FlavorTreat> JoinEntities { get; set; }
  }
}
