using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Dependencies
{
    public class SimpleInjectorServiceHost : ServiceHost
    {
        private readonly Container _container;
        public SimpleInjectorServiceHost(Type serviceType, Container container, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _container = container;
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new SimpleInjectorServiceBehavior(_container));
            base.OnOpening();
        }
    }
}
