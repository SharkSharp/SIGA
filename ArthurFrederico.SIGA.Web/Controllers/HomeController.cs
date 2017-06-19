using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}