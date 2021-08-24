using Microsoft.AspNetCore.Identity;

using LeekQuest.Models;

namespace LeekQuest.ViewModels {
  public class LoginResultViewModel {
    public SignInResult Result { get; set; }

    public UserViewModel User { get; set; }


    public LoginResultViewModel (SignInResult result, User user) {
      Result = result;
      User = new UserViewModel(user);
    }
  }
}