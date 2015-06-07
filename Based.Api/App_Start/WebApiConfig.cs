using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Based.Api.Converters;
using CacheCow.Server;
using CacheCow.Server.EntityTagStore.SqlServer;
using Newtonsoft.Json.Serialization;

namespace Based.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            // Default web view to JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Default JSON serialization to camel case
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();            
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Converters.Add(new LinkModelConverter());

            // Configure Caching/ETag Support
            var connString = ConfigurationManager.ConnectionStrings["DemoDb"].ConnectionString;
            var eTagStore = new SqlServerEntityTagStore(connString);
            var cacheHandler = new CachingHandler(config, eTagStore);

            config.MessageHandlers.Add(cacheHandler);
            
        }
    }
}