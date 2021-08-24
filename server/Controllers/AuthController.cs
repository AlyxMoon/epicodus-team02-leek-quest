namespace LeekQuest.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.IdentityModel.Tokens.Jwt;
  using System.Linq;
  using System.Net.Http.Headers;
  using System.Security.Claims;
  using System.Text;
  using System.Threading.Tasks;
  using LeekQuest.Models;
  using LeekQuest.ViewModels;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;
  using Microsoft.IdentityModel.Tokens;

  [ApiController]
  [Route("[controller]")]
  public class AuthController : Controller
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    private readonly IConfiguration _configuration;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<UserViewModel> GetAuthenticatedUser([FromHeader] string authorization)
    {
      // get the token from the user
      if (AuthenticationHeaderValue.TryParse(authorization, out AuthenticationHeaderValue headerValue))
      {
        string parameter = headerValue.Parameter;
        JwtSecurityTokenHandler handler = new ();
        JwtSecurityToken token = handler.ReadJwtToken(parameter);

        // get the username associated with that token
        string username = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;

        // use that username to query the database for the user
        User user = await _userManager.FindByNameAsync(username);

        // return the user!
        return new UserViewModel(user);
      }

      return new UserViewModel();
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

      List<Claim> authClaims = new ()
      {
        new Claim(ClaimTypes.Name, currentUser.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      };

      SymmetricSecurityKey authSigningKey = new (Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

      JwtSecurityToken token = new (
        expires: DateTime.Now.AddDays(14),
        claims: authClaims,
        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

      string generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

      return new LoginResultViewModel(result, currentUser, generatedToken);
    }

    [HttpGet("logout")]
    public async void Logout()
    {
      await _signInManager.SignOutAsync();
    }
  }
}