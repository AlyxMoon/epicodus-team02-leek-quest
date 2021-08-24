namespace LeekQuest.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      // ViewBag.Treats = _db.Treats.ToList();
      // ViewBag.Flavors = _db.Flavors.ToList();
      return View();
    }
  }
}