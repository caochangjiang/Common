using Autofac;
using Common.Components;
using System;

namespace Common.ThirdParty.Autofac
{
    public class AutofacObjectRegister : IObjectRegister
    {
        private ContainerBuilder _containerBuilder;
        public IObjectResolver GetObjectResolver()
        {
            return new AutofacObjectResolver(_containerBuilder);
        }
        public AutofacObjectRegister(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }
        public void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var registrationBuilder = _containerBuilder.RegisterType(implementationType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            if (life == LifeStyle.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }

        public void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var registrationBuilder = _containerBuilder.RegisterType(implementationType).As(serviceType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, serviceType);
            }
            if (life == LifeStyle.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }

        public void Register<TService, TImplementer>(string serviceName, LifeStyle life) where TService : class
            where TImplementer : class, TService
        {
            var registrationBuilder = _containerBuilder.RegisterType<TImplementer>().As<TService>();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            if (life == LifeStyle.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }

        public void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName) where TService : class
            where TImplementer : class, TService
        {
            var registrationBuilder = _containerBuilder.RegisterInstance(instance).As<TService>().SingleInstance();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
        }


    }
}
