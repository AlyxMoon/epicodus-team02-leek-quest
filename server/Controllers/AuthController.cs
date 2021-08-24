using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using LeekQuest.Models;
using LeekQuest.ViewModels;

namespace LeekQuest.Controllers
{
	[ApiController]
  [Route("[controller]")]
	public class AuthController : Controller
	{
		private readonly LeekQuestContext _db;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AuthController (UserManager<User> userManager, SignInManager<User> signInManager, LeekQuestContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
		}



		// public ActionResult Index()
		// {
		// 		return View();
		// }

		// public IActionResult Register()
		// {
		// 	return View();
		// }


		// [HttpPost]
		// public async Task<ActionResult> Register (RegisterViewModel model)
		// {
		// 	var user = new User { UserName = model.UserName };
		// 	IdentityResult result = await _userManager.CreateAsync(user, model.Password);
		// 	if (result.Succeeded)
		// 	{
		// 		return RedirectToAction("Index");
		// 	}
		// 	else
		// 	{
		// 		return View();
		// 	}
		// }
		[HttpPost("register")]
		public async Task<RegisterResultViewModel> Register(RegisterViewModel model) {
			User user = new() {
				Email = model.Email,
				UserName = model.UserName
			};

			IdentityResult result = await _userManager.CreateAsync(user, model.Password);

			return new RegisterResultViewModel (result, user);
		}

		// public ActionResult Login()
		// {
		// 	return View();
		// }

		// [HttpPost]
		// public async Task<ActionResult> Login(LoginViewModel model)
		// {
		// 	Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
		// 	if (result.Succeeded)
		// 	{
		// 		return RedirectToAction("Index");
		// 	}
		// 	else
		// 	{
		// 		return View();
		// 	}
		// }

		[HttpPost("login")]
    public async Task<LoginResultViewModel> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
        model.UserName,
        model.Password,
        isPersistent: true,
        lockoutOnFailure: false
      );

			User currentUser = await _userManager.FindByNameAsync(model.UserName);

			return new LoginResultViewModel(result, currentUser);
    }


		[HttpGet("logout")]
    public async void Logout ()
    {
      await _signInManager.SignOutAsync();
    }
	}
}