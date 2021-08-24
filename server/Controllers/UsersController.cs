// what can a user be able to do?

// register/login... is that in AuthController?
// [HttpPatch]? to update their position on the board
// view whole board with users on their corresponding position
// be mean/nice to another user
// view list of all chat messages
// post message on chat board
// click on another player and see bio
// go to jail if bad
// choose and edit color of person
// be able to view people in jail (if in jail or not)

namespace LeekQuest.Controllers
{
  using LeekQuest.Models;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  public class UsersController : Controller
  {
    // [HttpPatch]
    // public ActionResult MoveLeft(User user, int id, int PositionX, int PositionY)
    // {
    //   var thisUser = _db.Users
    //     .FirstOrDefault(user => user.UserId == id);
    //   thisUser.PositionX --
    // }
  }
}