namespace LeekQuest.ViewModels
{
  using LeekQuest.Models;
  using Microsoft.AspNetCore.Identity;

  public class RegisterResultViewModel
  {
    public IdentityResult Result { get; set; }

    public UserViewModel User { get; set; }

    public RegisterResultViewModel(IdentityResult result, User user)
    {
      Result = result;
      User = new UserViewModel(user);
    }
  }
}