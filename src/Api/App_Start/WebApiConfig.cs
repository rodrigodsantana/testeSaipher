using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            // Serviços e configuração da API da Web
            // New code
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            /*
             
             var constraints = new {httpMethod = new HttpMethodConstraint(HttpMethod.Options)};
 config.Routes.IgnoreRoute("OPTIONS", "*pathInfo",constraints);
             */

          
            
        }
    }
}
