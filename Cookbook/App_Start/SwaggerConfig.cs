using Cookbook;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cookbook
{
    using System.Web.Http;
    using Swashbuckle.Application;

    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => {
                        c.SingleApiVersion("v1", "Cookbook");
                        c.UseFullTypeNameInSchemaIds();
                    })
                .EnableSwaggerUi();
        }
    }
}
