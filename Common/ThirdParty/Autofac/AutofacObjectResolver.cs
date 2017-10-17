using Autofac;
using Common.Components;
using System;

namespace Common.ThirdParty.Autofac
{
    public class AutofacObjectResolver : IObjectResolver
    {
        private IContainer Container { get; set; }

        public ContainerBuilder ContainerBuilder { get; private set; }

        public AutofacObjectResolver(ContainerBuilder objectContainer)
        {
            ContainerBuilder = objectContainer;
        }
       
        public TService Resolve<TService>() where TService : class
        {
            return Container.Resolve<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return Container.ResolveNamed<TService>(serviceName);
        }

        public object ResolveNamed(string serviceName, Type serviceType)
        {
            return Container.ResolveNamed(serviceName, serviceType);
        }

        public object ResolveOptional(Type serviceType)
        {
            return Container.ResolveOptional(serviceType);
        }
    }
}
