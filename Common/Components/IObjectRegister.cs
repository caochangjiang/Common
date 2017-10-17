﻿using System;

namespace Common.Components
{
    public interface IObjectRegister
    {
        /// <summary>Register a implementation type.
        /// </summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>Register a implementer type instance as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="instance">The implementer type instance.</param>
        /// <param name="serviceName">The service name.</param>
        void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>Resolve a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <returns>The component instance that provides the service.</returns>
        IObjectResolver GetObjectResolver();
    }
}
