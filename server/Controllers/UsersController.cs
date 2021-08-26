namespace LeekQuest.Controllers
{
  using System.Collections.Generic;
  using System.IdentityModel.Tokens.Jwt;
  using System.Linq;
  using System.Net.Http.Headers;
  using System.Security.Claims;
  using System.Threading.Tasks;
  using LeekQuest.Models;
  using LeekQuest.ViewModels;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;

  [ApiController]
  [Route("/api/[controller]")]
  public class UsersController : Controller
  {
    private readonly UserManager<User> _userManager;
    private readonly LeekQuestContext _db;

    public UsersController(LeekQuestContext db, UserManager<User> userManager)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<List<UserViewModel>> Get()
    {
      List<User> userList = _db.Users.ToList();
      List<UserViewModel> userViewModelsList = new ();
      foreach (User user in userList)
      {
        userViewModelsList.Add(new UserViewModel(user));
      }

      return userViewModelsList;
    }

    // GET: api/Users/"id"
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UserViewModel>> GetUser(string id)
    {
        User user = await _db.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return new UserViewModel(user);
    }

    // Post: api/Users/"id"/position
    [HttpPost("position")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult<UserPositionViewModel>> MovePlayer([FromHeader] string authorization, string direction)
    {
      if (AuthenticationHeaderValue.TryParse(authorization, out AuthenticationHeaderValue headerValue))
      {
        string parameter = headerValue.Parameter;
        JwtSecurityTokenHandler handler = new ();
        JwtSecurityToken token = handler.ReadJwtToken(parameter);

        string username = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;

        User user = await _userManager.FindByNameAsync(username);

        int newX = user.PositionX;
        int newY = user.PositionY;
        string message = "Nice Move...";
        switch (direction)
        {
          case "Up":
            newY--;
            break;
          case "Down":
            newY++;
            break;
          case "Right":
            newX++;
            break;
          case "Left":
            newX--;
            break;
          case "UpLeft":
            newY--;
            newX--;
            break;
          case "UpRight":
            newY--;
            newX++;
            break;
          case "DownRight":
            newY++;
            newX++;
            break;
          case "DownLeft":
            newY++;
            newX--;
            break;
        }

        if (newY >= 0 && newY <= 99 && newX >= 0 && newX <= 99)
        {
          user.PositionY = newY;
          user.PositionX = newX;
          _db.SaveChanges();
        }
        else
        {
          message = "Please make a valid move, you can't leave the board!";
        }

        return new UserPositionViewModel(user, message);
      }

      return new UserPositionViewModel();
    }

    [HttpGet("poop")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<UserViewModel> GetAuthenticatedUser([FromHeader] string authorization)
    {
      if (AuthenticationHeaderValue.TryParse(authorization, out AuthenticationHeaderValue headerValue))
      {
        string parameter = headerValue.Parameter;
        JwtSecurityTokenHandler handler = new ();
        JwtSecurityToken token = handler.ReadJwtToken(parameter);

        string username = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;

        User user = await _userManager.FindByNameAsync(username);

        return new UserViewModel(user);
      }

      return new UserViewModel();
    }
  }
}