using System.Web.Mvc;
using MyLibrary.Providers;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Condition = User.Identity.IsAuthenticated;//restircted permission to some actions(see Index.cshtml)
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}