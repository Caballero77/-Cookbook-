using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Cookbook
{
    using Newtonsoft.Json;

    using Swashbuckle.Application;

    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        ///     The ISO date format
        ///     <see cref="https://www.w3.org/TR/NOTE-datetime"/>
        /// </summary>
        private static string IsoDateFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffffff";

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependenciesConfig.Register);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.NullValueHandling =
                NullValueHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.DateFormatString =
                IsoDateFormat;
        }
    }
}
