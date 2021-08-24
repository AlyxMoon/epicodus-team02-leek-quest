using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

using LeekQuest.Models;

namespace LeekQuest.Controllers
{
  public class ChatMessagesController : Controller
  {
    private readonly LeekQuestContext _db;
    private readonly UserManager<User> _userManager;

    public ChatMessagesController(UserManager<User> userManager, LeekQuestContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<ChatMessage> model = _db.ChatMessages.ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ChatMessage chatMessage)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      chatMessage.User = currentUser;
      _db.ChatMessages.Add(chatMessage);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisChatMessage = _db.ChatMessages.FirstOrDefault(chatMessage => chatMessage.ChatMessageId == id);
      return View(thisChatMessage);
    }

    [Authorize]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisChatMessage = _db.ChatMessages.FirstOrDefault(chatMessage => chatMessage.ChatMessageId == id);
      _db.ChatMessages.Remove(thisChatMessage);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}