namespace LeekQuest.ViewModels
{
  using LeekQuest.Models;
  using Microsoft.AspNetCore.Identity;
  public class LoginResultViewModel
  {
    public SignInResult Result { get; set; }
    public UserViewModel User { get; set; }

    public string Token { get; set; }
    public LoginResultViewModel(SignInResult result, User user, string token)
    {
      Result = result;
      User = new UserViewModel(user);
      Token = token;
    }
  }
}