namespace LeekQuest.Models
{
  public class ChatMessage
  {
    public int ChatMessageId { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    public string TimeStamp { get; set; }
    public int NumLikes { get; set; }
    public virtual User User { get; set; }
  }
}
