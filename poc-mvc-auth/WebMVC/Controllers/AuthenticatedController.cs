using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class AuthenticatedController : Controller
    {
        // GET: Authenticated
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                ViewBag.Title = "Authenticated Page";

                return View();
            }
            else
            {
                return RedirectToAction("Demo");
            }
        }

        public ActionResult Demo()
        {
            ViewBag.Title = "Not Authenticated Page";

            return View();
        }
    }
}