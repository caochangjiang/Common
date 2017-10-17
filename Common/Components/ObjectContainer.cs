using System;

namespace Common.Components
{
    /// <summary>
    /// Dependency injection container
    /// </summary>
    public class ObjectContainer
    {
        private static IObjectRegister _objectRegister;
        private static IObjectResolver _objectResolver;

        /// <summary>
        /// Set register
        /// </summary>
        /// <param name="objectRegister">the class which implemete IObjectRegister</param>
        public static void SetRegister(IObjectRegister objectRegister)
        {
            _objectRegister = objectRegister;
        }

        /// <summary>
        /// Get the Resolver
        /// </summary>
        /// <returns>IObjectResolver</returns>
        public static IObjectResolver GetResolver()
        {
            _objectResolver = _objectRegister.GetObjectResolver();
            return _objectResolver;
        }

        /// <summary>Register a implementation type.
        /// </summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        public static void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            _objectRegister.RegisterType(implementationType, serviceName, life);
        }

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        public static void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            _objectRegister.RegisterType(serviceType, implementationType, serviceName, life);

        }

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        public static void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            _objectRegister.Register<TService, TImplementer>(serviceName, life);
        }

        /// <summary>Register a implementer type instance as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="instance">The implementer type instance.</param>
        /// <param name="serviceName">The service name.</param>
        public static void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            _objectRegister.RegisterInstance<TService, TImplementer>(instance, serviceName);
        }

        /// <summary>Resolve a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <returns>The component instance that provides the service.</returns>
        public static TService Resolve<TService>() where TService : class
        {
            return _objectResolver.Resolve<TService>();
        }

        /// <summary>Resolve a service.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The component instance that provides the service</returns>
        public static object Resolve(Type serviceType)
        {
            return _objectResolver.Resolve(serviceType);
        }

        /// <summary>Resolve a service or null if the service is not registed
        /// </summary>
        /// <param name="serviceType">The service type or null</param>
        /// <returns>The component instance that provides the service or null if the service is not registed</returns>
        public static object ResolveOptional(Type serviceType)
        {
            return _objectResolver.ResolveOptional(serviceType);
        }

        /// <summary>
        /// Resolve a service or null with the servcieName
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceName">The serviceName</param>
        /// <returns></returns>
        public static TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return _objectResolver.ResolveNamed<TService>(serviceName);
        }

        /// <summary>
        /// Resolve a service by serviceName and serviceType
        /// </summary>
        /// <param name="serviceName">the serivce name</param>
        /// <param name="serviceType">the service type</param>
        /// <returns></returns>
        public static object ResolveNamed(string serviceName, Type serviceType)
        {
            return _objectResolver.ResolveNamed(serviceName, serviceType);
        }
    }

    /// <summary>An enum to description the lifetime of a component.
    /// </summary>
    public enum LifeStyle
    {
        /// <summary>Represents a component is a transient component.
        /// </summary>
        Transient,
        /// <summary>Represents a component is a singleton component.
        /// </summary>
        Singleton
    }
}
