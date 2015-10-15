using SchoolService.Dependencies;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace DependencyHandler
{
    public class SimpleInjectorWebServiceHostFactory : ServiceHostFactory
    {
        private readonly Container _container;
        public SimpleInjectorWebServiceHostFactory(Container container)
        {
            _container = container;
        }
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new SimpleInjectorServiceHost(serviceType, _container, baseAddresses);
        }
        
    }
}
