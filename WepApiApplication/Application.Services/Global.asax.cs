using Application.DataLayer;
using Application.Services.Resolver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Application.Services
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //this.ConfigureDependencyResolver(GlobalConfiguration.Configuration);

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new DbDependencyResolver();

            Database.SetInitializer<NewPlacesContext>(new DropCreateDatabaseIfModelChanges<NewPlacesContext>());
        }

        //protected void ConfigureDependencyResolver(HttpConfiguration config)
        //{
        //    config.DependencyResolver = new DbDependencyResolver();
        //}


    }
}