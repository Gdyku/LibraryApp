﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Library.Mapper;

namespace Library
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var config = new MapperConfiguration(cfg =>
            {
               cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }
    }
}
