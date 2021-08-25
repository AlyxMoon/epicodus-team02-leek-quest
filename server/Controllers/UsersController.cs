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
    private readonly LeekQuestContext _db;

    public UsersController(LeekQuestContext db)
    {
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
        var user = await _db.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return new UserViewModel(user);
    }

    //Patch: api/Users/"id"
    [HttpPut("{id"})]
    [Authorize]
    
  }
}