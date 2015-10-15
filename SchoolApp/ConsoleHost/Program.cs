using Helper;
using SchoolService;
using SchoolService.Dependencies;
using SchoolService.WCFServices;
using SchoolService.WCFServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = SingletonContainer.Instance;
            DependencyLoader.LoadDependency(container);
            MapLoader.LoadMappings();
            var types = typeof(MasterService).Assembly.GetTypes().ToList();
            var contracts = types.Where(x => x.IsInterface & x.GetCustomAttributes(true).OfType<ServiceContractAttribute>().Any());
            foreach (var contract in contracts)
            {
                var serviceType = types.FirstOrDefault(x => contract.IsAssignableFrom(x) && !x.IsInterface);
                if (serviceType != null)
                {
                    var host = new SimpleInjectorServiceHost(serviceType, container);
                    host.Open();
                }

            }
            Console.ReadLine();
            //using (var host1 = new SimpleInjectorServiceHost(typeof(LoginService), container))
            //{
            //    var host2 = new SimpleInjectorServiceHost(typeof(MasterService), container);
            //    host1.Open();
            //    host2.Open();
            //    var host3 = new SimpleInjectorServiceHost(typeof(TeacherService), container);
            //    host3.Open();
            //    Console.ReadLine();
            //}


        }
    }
}
