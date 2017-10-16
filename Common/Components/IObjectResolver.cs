using System;

namespace Common.Components
{
    public interface IObjectResolver
    {
        TService Resolve<TService>() where TService : class;
        /// <summary>Resolve a service.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The component instance that provides the service.</returns>
        object Resolve(Type serviceType);
        /// <summary>Resolve a service or null if the service is not registed
        /// </summary>
        /// <param name="serviceType">The service type or null</param>
        /// <returns>The component instance that provides the service or null if the service is not registed</returns>
        object ResolveOptional(Type serviceType);
        /// <summary>Resolve a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="serviceName">The service name.</param>
        /// <returns>The component instance that provides the service.</returns>
        TService ResolveNamed<TService>(string serviceName) where TService : class;
        /// <summary>Resolve a service.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The component instance that provides the service.</returns>
        object ResolveNamed(string serviceName, Type serviceType);
    }
}
