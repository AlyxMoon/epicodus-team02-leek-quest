namespace LeekQuest.ViewModels
{
  using LeekQuest.Models;

  public class UserPositionViewModel
  {
    public string Message { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool Success { get; set; }
    public UserPositionViewModel()
    {
    }

    public UserPositionViewModel(User user, string message, bool success)
    {
      Success = success;
      Message = message;
      PositionX = user.PositionX;
      PositionY = user.PositionY;
    }
  }
}
