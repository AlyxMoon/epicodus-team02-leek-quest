namespace LeekQuest.Controllers
{
  using System.Collections.Generic;
  using System.Linq;
  using LeekQuest.Models;
  using Microsoft.AspNetCore.Mvc;
  public class UserRelationshipsController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}