using DependencyHandler;
using SchoolService;
using SchoolService.WCFServices;
using SchoolService.WCFServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { isMatch = new DefaultConstraint() }
           );
            routes.Add(new ServiceRoute("SVC/MaterService", new SimpleInjectorWebServiceHostFactory(SingletonContainer.Instance), typeof(MasterService)));
            routes.Add(new ServiceRoute("SVC/StudentService", new SimpleInjectorWebServiceHostFactory(SingletonContainer.Instance), typeof(StudentService)));
            routes.Add(new ServiceRoute("SVC/TeacherService", new SimpleInjectorWebServiceHostFactory(SingletonContainer.Instance), typeof(TeacherService)));
            routes.Add(new ServiceRoute("SVC/LoginService", new SimpleInjectorWebServiceHostFactory(SingletonContainer.Instance), typeof(LoginService)));


        }
    }
}
