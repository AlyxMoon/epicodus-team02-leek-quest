using Microsoft.AspNetCore.Mvc;
using LeekQuest.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeekQuest.Controllers
{
  public class UserRelationshipsController : Controller
  {
    private readonly LeekQuestContext _db;
    public UserRelationshipsController(LeekQuestContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}