using Microsoft.AspNetCore.Mvc;
using LeekQuest.Models;
using System.Linq;


namespace LeekQuest.Controllers
{
  public class HomeController : Controller
  {
    private readonly LeekQuestContext _db;
    public HomeController(LeekQuestContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      // ViewBag.Treats = _db.Treats.ToList();
      // ViewBag.Flavors = _db.Flavors.ToList();
      return View();
    }
  }
}