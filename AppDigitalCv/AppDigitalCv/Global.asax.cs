using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AppDigitalCv.App_Start;
using AppDigitalCv.Controllers;
using AppDigitalCv.Infraestructure;

namespace AppDigitalCv
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomaperWebProfile.Run();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();

            if (new HttpRequestWrapper(httpContext.Request).IsAjaxRequest())
            {
                return;
            }

            ExecuteErrorController(httpContext, exception as HttpException);
        }

        private void ExecuteErrorController(HttpContext httpContext, HttpException exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";

            if (exception != null && exception.GetHttpCode() == (int)HttpStatusCode.NotFound)
            {
                routeData.Values["action"] = "NotFound";
            }
            else
            {
                routeData.Values["action"] = "InternalServerError";
            }

            using (Controller controller = new ErrorController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
    }
}