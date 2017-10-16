using Autofac;
using Common.Components;
using Common.ThirdParty.Autofac;

namespace Common.Configurations
{
    public static class CommonConfigurationExtensions
    {
        public static CommonConfiguration UseAutofac(this CommonConfiguration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }
        public static CommonConfiguration UseAutofac(this CommonConfiguration configuration, ContainerBuilder container)
        {
            ObjectContainer.SetRegister(new AutofacObjectRegister(container));
            return configuration;
        }
        
    }
}
