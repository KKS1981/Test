using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Dependencies
{
    public class SimpleInjectorInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly Container _container;
        public SimpleInjectorInstanceProvider(Type serviceType, Container container)
        {
            _serviceType = serviceType;
            _container = container;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _container.GetInstance(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
