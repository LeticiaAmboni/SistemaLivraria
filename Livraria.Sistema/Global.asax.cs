using Livraria.Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Livraria.Sistema
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
