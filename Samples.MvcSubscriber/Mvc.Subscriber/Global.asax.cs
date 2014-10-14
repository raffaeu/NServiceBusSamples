using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Mvc.Subscriber
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus Bus;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /// initialize a new configuration
            var configuration = new BusConfiguration();
            /// set the transport mechanism
            configuration.UseTransport<MsmqTransport>();
            /// set the persistence mechanism
            configuration.UsePersistence<InMemoryPersistence>();
            /// here we specify the InProcess endpoint to listen to
            /// can be only one per process (See Service Bus pattern by Fowler)
            configuration.EndpointName("MvcSubscriber");

            Task.Run(() =>
            {
                NServiceBus.Bus.Create(configuration).Start();
            });

        }
    }
}
