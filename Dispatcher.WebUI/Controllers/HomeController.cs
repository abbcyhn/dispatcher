namespace Dispatcher.WebUI.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentAndGroup()
        {
            return View();
        }
    }
}