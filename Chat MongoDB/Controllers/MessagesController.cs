using Microsoft.AspNetCore.Mvc;

namespace Chat_MongoDB.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
