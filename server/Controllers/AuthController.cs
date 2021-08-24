namespace LeekQuest.Controllers
{
  using System.Threading.Tasks;
  using LeekQuest.Models;
  using LeekQuest.ViewModels;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;

  [ApiController]
  [Route("[controller]")]
  public class AuthController : Controller
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<RegisterResultViewModel> Register(RegisterViewModel model)
    {
      User user = new ()
      {
        Email = model.Email,
        UserName = model.UserName
      };

      IdentityResult result = await _userManager.CreateAsync(user, model.Password);

      return new RegisterResultViewModel(result, user);
    }

    [HttpPost("login")]
    public async Task<LoginResultViewModel> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
        model.UserName,
        model.Password,
        isPersistent: true,
        lockoutOnFailure: false);

      User currentUser = await _userManager.FindByNameAsync(model.UserName);
      return new LoginResultViewModel(result, currentUser);
    }

    [HttpGet("logout")]
    public async void Logout()
    {
      await _signInManager.SignOutAsync();
    }
  }
}