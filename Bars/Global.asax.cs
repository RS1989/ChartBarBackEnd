using Bars.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;

namespace Bars
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IRandomizaProvider, RandomizaProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IColorProvider, ColorProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IValidationProvider, ValidationProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataParserProvider, DataParserProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataProvider, DataProvider>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);


        }
    }
}
