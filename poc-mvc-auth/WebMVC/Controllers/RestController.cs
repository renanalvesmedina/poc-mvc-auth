using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5173", headers: "*", methods: "*", SupportsCredentials = true)]
    public class RestController : ApiController
    {
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        [SwaggerResponse(HttpStatusCode.OK)]
        public JsonResult<string> Login(string userName, string password)
        {
            if (userName == "super" && password == "123@Qwe")
            {
                if ((HttpContext.Current.Session["userName"] as string) == null)
                    HttpContext.Current.Session["userName"] = userName;

                return Json(HttpContext.Current.Session["userName"].ToString());
            }

            return Json("");
        }
    }
}
