using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using LeekQuest.Models;
using LeekQuest.ViewModels;

namespace LeekQuest.Controllers
{
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

		public ActionResult Index()
		{
				return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register (RegisterViewModel model)
		{
			var user = new User { UserName = model.UserName };
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		public async Task<ActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}