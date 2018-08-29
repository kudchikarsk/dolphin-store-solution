using AutoMapper;
using DA.ClientManagement.Core.Models;
using DA.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI
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

            var container = IOC.Initialize();
            DomainEvents.Container = container;
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<Toner, TonerViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });
        }
    }
}
