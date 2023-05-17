using System.Web.Http;
using System.Web.Routing;
using WebMVC.SessionHandlers;

namespace WebMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();


            RouteTable.Routes.MapHttpRoute(
                name: "Rest",
                routeTemplate: "api/rest/login",
                defaults: new { controller = "Rest", action = "Login" }
            ).RouteHandler = new SessionStateRouteHandler();
        }
    }
}
